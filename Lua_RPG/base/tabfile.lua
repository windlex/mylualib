-- 模拟tabfile的操作
-- by windle 2009-1-15 16:46

g_TabFiles = {
}

openfile = io.open
close = io.close
read = io.read
tinsert = table.insert

TabFile = {}
function TabFile.open(filename, spe)
	print("spe4", spe)
	--local filename1 = __DBGLIB:getBasePath().."\\服务端配置文件\\GameSvr"..filename;
	--local filename2 = __DBGLIB:getBasePath().."\\设定文件"..filename;
	spe = spe or "\t"
	local newFile = openfile(filename, "r") or openfile(filename1, "r") or openfile(filename2, "r");
	if not newFile then
		print("------------------------------- [file] openfile error", filename1);
		return
	end
	g_TabFiles[filename] = {}
	local i = 0;
	while 1 do
		i = i + 1
		
		local line = newFile:read("*l");
		if line == nil then
			break;
		else
			line = line ..spe;
		end
		local t = {};
		gsub(line, "(.-)"..spe, function(v) tinsert(t,v) end)
		g_TabFiles[filename][i] = t;
	end
	return 1;
end

function TabFile.Load(filename, spe)
	print("spe", spe)
	if not g_TabFiles[filename] then
		g_TabFiles.filename = TabFile.open(filename, spe);
	end
	return g_TabFiles.filename;
end

function TabFile.Unload()
end

function TabFile.GetData(filename, row, col)
	if not g_TabFiles[filename] or not g_TabFiles[filename][row] then
		print(format("[TabFile_GetData] [Error GetData] [file=%s, row=%s, col=%s]", filename, row, col));
		return nil;
	end
	if type(col) == "string" then
		local nTotalCol = #(g_TabFiles[filename][row]);
		for i=1, nTotalCol do
			if col == g_TabFiles[filename][1][i] then
				col = i;
				break
			end
		end
	end
	return g_TabFiles[filename][row][col];
end

function TabFile.GetRowCount(filename)
	return #(g_TabFiles[filename]);
end

function TabFile.GetColCount(filename)
	return #(g_TabFiles[filename][1]);
end

KTabFile = class {
	_ctor = function(self, filename, spe)
	print("spe", spe)
		return self:load(filename, spe);
	end,
	__encodeType = 0,

	load = function(self,filename, spe)
	print("spe", spe)
		self.__filename = filename
		if(TabFile.Load(filename, spe) ==0) then
			return nil
		end
		self.__bOpen = 1;
		return 1
	end,

	getCell = function(self,row,col)
		return TabFile.GetData(self.__filename,row,col, "", self.__encodeType)
	end,

	getRow = function(self)
		return TabFile.GetRowCount(self.__filename)
	end,
	
	getCol = function(self)
		return TabFile.GetColCount(self.__filename)
	end,

	-- 根据列名取出单列作为一个单维数组
	createArray = function(self, col)
		local nRow = self:getRow();
		local ary = {};
		local i=0;
		
		for i=3, nRow do
			rawset(ary, #(ary)+1, self:getCell(i, col));
		end;
		
		return ary;
		
	end,
	
	-- 根据列来确定该数值的行为第几行（数字）
	selectRowNum = function(self, col, value)
		local nRow = self:getRow();
		local i=0;
		
		for i=3, nRow do
			if tonumber(self:getCell(i, col))==value then
				return i;
			end;
		end;
		
		return 0;
	end,
	
	-- 根据列来确定该数值的行为第几行（字符）
	selectRowString = function(self, col, value)
		local nRow = self:getRow();
		local i=0;
		
		for i=3, nRow do
			if self:getCell(i, col)==value then
				return i;
			end;
		end;
		
		return 0;	
	end,
	
	--关闭
	close = function(self)
		if self.__bOpen ~= 0 then
			local bCloseFailed = 0;
			local nCnt = 10;--最多尝试删除10次
			repeat
				bCloseFailed = TabFile.Unload(self.__filename);
				nCnt = nCnt - 1;
			until bCloseFailed == 0 or nCnt <= 0;
		end
		self.__filename = nil;
		self.__bOpen = 0;
	end,
}

function ff_GetTabFileTable(szFilePath,nDataStartLine,handles, lineHandler, spe)
	handles = handles or {}
	nDataStartLine = nDataStartLine or 2;	--真正的数据默认从第2行开始
	local tbFile = KTabFile(szFilePath, spe);
	if not tbFile then
		TabFile.Unload(szFilePath);
		return {};
	end;
	local nRow = tbFile:getRow();
	local nCol = tbFile:getCol();
	local tbRet = {};
	tbRet[0] = {};
	for i = 1, nCol do
		tbRet[0][i] = tbFile:getCell(1,i);	--索引0为表头内容
	end;	
	for i = 1, nRow-nDataStartLine+1 do
		tbRet[i] = {};
		for j = 1, nCol do
			local szKey = tbRet[0][j];
			local data = tbFile:getCell(i+nDataStartLine-1,j);	--读数据
			local err
			if handles[szKey] then
				data, err = handles[szKey](data);
			elseif handles[j] then
				data, err = handles[j](data);
			end
			if err then
				error(err)
			end
			tbRet[i][j] = data;
		end;
		if lineHandler then
			lineHandler(tbRet[i]);
		end
	end;
	tbFile:close();
	return tbRet;
end;

--以表头字符作为索引
function ff_GetTabFileTableEx(szFilePath,nDataStartLine,handles, lineHandler, spe)
	print("spe", spe)
	handles = handles or {}
	nDataStartLine = nDataStartLine or 2;
	--szFilePath = sf_RemoveEndSpace(szFilePath)
	local tbFile = KTabFile(szFilePath, spe);
	if not tbFile then
		TabFile.Unload(szFilePath);
		return {};
	end;
	local nRow = tbFile:getRow();
	local nCol = tbFile:getCol();
	local tbRet = {};
	tbRet[0] = {};
	for j = 1, nCol do
		tbRet[0][j] = gsub(tbFile:getCell(1, j), " ", ""); --索引0为表头内容
	end;	
	for i = 1, nRow-nDataStartLine+1 do
		tbRet[i] = {};
		for j = 1, nCol do
			local szKey = tbRet[0][j];
			local data = tbFile:getCell(i+nDataStartLine-1, j);
			local err
			if handles[szKey] then
				data, err = handles[szKey](data);
			elseif handles[j] then
				data, err = handles[j](data);
			end
			if err then
				error(err)
			end
			tbRet[i][szKey] = data;
		end;
		if lineHandler then
			lineHandler(tbRet[i]);
		end
	end;
	tbFile:close();
	return tbRet;
end;
