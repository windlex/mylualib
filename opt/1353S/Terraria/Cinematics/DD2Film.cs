using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.ID;

namespace Terraria.Cinematics
{
	// Token: 0x02000194 RID: 404
	public class DD2Film : Film
	{
		// Token: 0x06001308 RID: 4872 RVA: 0x00419ED0 File Offset: 0x004180D0
		public DD2Film()
		{
			base.AppendKeyFrames(new FrameEvent[]
			{
				new FrameEvent(this.CreateDryad),
				new FrameEvent(this.CreateCritters)
			});
			base.AppendSequences(120, new FrameEvent[]
			{
				new FrameEvent(this.DryadStand),
				new FrameEvent(this.DryadLookRight)
			});
			base.AppendSequences(100, new FrameEvent[]
			{
				new FrameEvent(this.DryadLookRight),
				new FrameEvent(this.DryadInteract)
			});
			base.AddKeyFrame(base.AppendPoint - 20, new FrameEvent(this.CreatePortal));
			base.AppendSequences(30, new FrameEvent[]
			{
				new FrameEvent(this.DryadLookLeft),
				new FrameEvent(this.DryadStand)
			});
			base.AppendSequences(40, new FrameEvent[]
			{
				new FrameEvent(this.DryadConfusedEmote),
				new FrameEvent(this.DryadStand),
				new FrameEvent(this.DryadLookLeft)
			});
			base.AppendKeyFrame(new FrameEvent(this.CreateOgre));
			base.AddKeyFrame(base.AppendPoint + 60, new FrameEvent(this.SpawnJavalinThrower));
			base.AddKeyFrame(base.AppendPoint + 120, new FrameEvent(this.SpawnGoblin));
			base.AddKeyFrame(base.AppendPoint + 180, new FrameEvent(this.SpawnGoblin));
			base.AddKeyFrame(base.AppendPoint + 240, new FrameEvent(this.SpawnWitherBeast));
			base.AppendSequences(30, new FrameEvent[]
			{
				new FrameEvent(this.DryadStand),
				new FrameEvent(this.DryadLookLeft)
			});
			base.AppendSequences(30, new FrameEvent[]
			{
				new FrameEvent(this.DryadLookRight),
				new FrameEvent(this.DryadWalk)
			});
			base.AppendSequences(300, new FrameEvent[]
			{
				new FrameEvent(this.DryadAttack),
				new FrameEvent(this.DryadLookLeft)
			});
			base.AppendKeyFrame(new FrameEvent(this.RemoveEnemyDamage));
			base.AppendSequences(60, new FrameEvent[]
			{
				new FrameEvent(this.DryadLookRight),
				new FrameEvent(this.DryadStand),
				new FrameEvent(this.DryadAlertEmote)
			});
			base.AddSequences(base.AppendPoint - 90, 60, new FrameEvent[]
			{
				new FrameEvent(this.OgreLookLeft),
				new FrameEvent(this.OgreStand)
			});
			base.AddKeyFrame(base.AppendPoint - 12, new FrameEvent(this.OgreSwingSound));
			base.AddSequences(base.AppendPoint - 30, 50, new FrameEvent[]
			{
				new FrameEvent(this.DryadPortalKnock),
				new FrameEvent(this.DryadStand)
			});
			base.AppendKeyFrame(new FrameEvent(this.RestoreEnemyDamage));
			base.AppendSequences(40, new FrameEvent[]
			{
				new FrameEvent(this.DryadPortalFade),
				new FrameEvent(this.DryadStand)
			});
			base.AppendSequence(180, new FrameEvent(this.DryadStand));
			base.AddSequence(0, base.AppendPoint, new FrameEvent(this.PerFrameSettings));
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x0041A248 File Offset: 0x00418448
		private void PerFrameSettings(FrameEventData evt)
		{
			CombatText.clearAll();
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x0041A250 File Offset: 0x00418450
		private void CreateDryad(FrameEventData evt)
		{
			this._dryad = this.PlaceNPCOnGround(20, this._startPoint);
			this._dryad.knockBackResist = 0f;
			this._dryad.immortal = true;
			this._dryad.dontTakeDamage = true;
			this._dryad.takenDamageMultiplier = 0f;
			this._dryad.immune[255] = 100000;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0041A2C0 File Offset: 0x004184C0
		private void DryadInteract(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				this._dryad.ai[0] = 9f;
				if (evt.IsFirstFrame)
				{
					this._dryad.ai[1] = (float)evt.Duration;
				}
				this._dryad.localAI[0] = 0f;
			}
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x0041A318 File Offset: 0x00418518
		private void SpawnWitherBeast(FrameEventData evt)
		{
			int num = NPC.NewNPC((int)this._portal.Center.X, (int)this._portal.Bottom.Y, 568, 0, 0f, 0f, 0f, 0f, 255);
			NPC nPC = Main.npc[num];
			nPC.knockBackResist = 0f;
			nPC.immortal = true;
			nPC.dontTakeDamage = true;
			nPC.takenDamageMultiplier = 0f;
			nPC.immune[255] = 100000;
			nPC.friendly = this._ogre.friendly;
			this._army.Add(nPC);
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x0041A3C8 File Offset: 0x004185C8
		private void SpawnJavalinThrower(FrameEventData evt)
		{
			int num = NPC.NewNPC((int)this._portal.Center.X, (int)this._portal.Bottom.Y, 561, 0, 0f, 0f, 0f, 0f, 255);
			NPC nPC = Main.npc[num];
			nPC.knockBackResist = 0f;
			nPC.immortal = true;
			nPC.dontTakeDamage = true;
			nPC.takenDamageMultiplier = 0f;
			nPC.immune[255] = 100000;
			nPC.friendly = this._ogre.friendly;
			this._army.Add(nPC);
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x0041A478 File Offset: 0x00418678
		private void SpawnGoblin(FrameEventData evt)
		{
			int num = NPC.NewNPC((int)this._portal.Center.X, (int)this._portal.Bottom.Y, 552, 0, 0f, 0f, 0f, 0f, 255);
			NPC nPC = Main.npc[num];
			nPC.knockBackResist = 0f;
			nPC.immortal = true;
			nPC.dontTakeDamage = true;
			nPC.takenDamageMultiplier = 0f;
			nPC.immune[255] = 100000;
			nPC.friendly = this._ogre.friendly;
			this._army.Add(nPC);
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x0041A528 File Offset: 0x00418728
		private void CreateCritters(FrameEventData evt)
		{
			for (int i = 0; i < 5; i++)
			{
				float num = (float)i / 5f;
				NPC nPC = this.PlaceNPCOnGround((int)Utils.SelectRandom<short>(Main.rand, new short[]
				{
					46,
					46,
					299,
					538
				}), this._startPoint + new Vector2((num - 0.25f) * 400f + Main.rand.NextFloat() * 50f - 25f, 0f));
				nPC.ai[0] = 0f;
				nPC.ai[1] = 600f;
				this._critters.Add(nPC);
			}
			if (this._dryad == null)
			{
				return;
			}
			for (int j = 0; j < 10; j++)
			{
				float arg_B4_0 = (float)j / 10f;
				int num2 = NPC.NewNPC((int)this._dryad.position.X + Main.rand.Next(-1000, 800), (int)this._dryad.position.Y - Main.rand.Next(-50, 300), 356, 0, 0f, 0f, 0f, 0f, 255);
				NPC nPC2 = Main.npc[num2];
				nPC2.ai[0] = Main.rand.NextFloat() * 4f - 2f;
				nPC2.ai[1] = Main.rand.NextFloat() * 4f - 2f;
				nPC2.velocity.X = Main.rand.NextFloat() * 4f - 2f;
				this._critters.Add(nPC2);
			}
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x0041A6DC File Offset: 0x004188DC
		private void OgreSwingSound(FrameEventData evt)
		{
			Main.PlaySound(SoundID.DD2_OgreAttack, this._ogre.Center);
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x0041A6F4 File Offset: 0x004188F4
		private void DryadPortalKnock(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				if (evt.Frame == 20)
				{
					NPC expr_26_cp_0_cp_0 = this._dryad;
					expr_26_cp_0_cp_0.velocity.Y = expr_26_cp_0_cp_0.velocity.Y - 7f;
					NPC expr_3F_cp_0_cp_0 = this._dryad;
					expr_3F_cp_0_cp_0.velocity.X = expr_3F_cp_0_cp_0.velocity.X - 8f;
					Main.PlaySound(3, (int)this._dryad.Center.X, (int)this._dryad.Center.Y, 1, 1f, 0f);
				}
				if (evt.Frame >= 20)
				{
					this._dryad.ai[0] = 1f;
					this._dryad.ai[1] = (float)evt.Remaining;
					this._dryad.rotation += 0.05f;
				}
			}
			if (this._ogre != null)
			{
				if (evt.Frame > 40)
				{
					this._ogre.target = Main.myPlayer;
					this._ogre.direction = 1;
					return;
				}
				this._ogre.direction = -1;
				this._ogre.ai[1] = 0f;
				this._ogre.ai[0] = Math.Min(40f, this._ogre.ai[0]);
				this._ogre.target = 300 + this._dryad.whoAmI;
			}
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x0041A858 File Offset: 0x00418A58
		private void RemoveEnemyDamage(FrameEventData evt)
		{
			this._ogre.friendly = true;
			using (List<NPC>.Enumerator enumerator = this._army.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.friendly = true;
				}
			}
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0041A8B8 File Offset: 0x00418AB8
		private void RestoreEnemyDamage(FrameEventData evt)
		{
			this._ogre.friendly = false;
			using (List<NPC>.Enumerator enumerator = this._army.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.friendly = false;
				}
			}
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x0041A918 File Offset: 0x00418B18
		private void DryadPortalFade(FrameEventData evt)
		{
			if (this._dryad != null && this._portal != null)
			{
				if (evt.IsFirstFrame)
				{
					Main.PlaySound(SoundID.DD2_EtherianPortalDryadTouch, this._dryad.Center);
				}
				float num = (float)(evt.Frame - 7) / (float)(evt.Duration - 7);
				num = Math.Max(0f, num);
				this._dryad.color = new Color(Vector3.Lerp(Vector3.One, new Vector3(0.5f, 0f, 0.8f), num));
				this._dryad.Opacity = 1f - num;
				this._dryad.rotation += 0.05f * (num * 4f + 1f);
				this._dryad.scale = 1f - num;
				if (this._dryad.position.X < this._portal.Right.X)
				{
					NPC expr_101_cp_0_cp_0 = this._dryad;
					expr_101_cp_0_cp_0.velocity.X = expr_101_cp_0_cp_0.velocity.X * 0.95f;
					NPC expr_11A_cp_0_cp_0 = this._dryad;
					expr_11A_cp_0_cp_0.velocity.Y = expr_11A_cp_0_cp_0.velocity.Y * 0.55f;
				}
				int num2 = (int)(6f * num);
				float num3 = this._dryad.Size.Length() / 2f;
				num3 /= 20f;
				for (int i = 0; i < num2; i++)
				{
					if (Main.rand.Next(5) == 0)
					{
						Dust expr_1BA = Dust.NewDustDirect(this._dryad.position, this._dryad.width, this._dryad.height, 27, this._dryad.velocity.X * 1f, 0f, 100, default(Color), 1f);
						expr_1BA.scale = 0.55f;
						expr_1BA.fadeIn = 0.7f;
						expr_1BA.velocity *= 0.1f * num3;
						expr_1BA.velocity += this._dryad.velocity;
					}
				}
			}
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0041AB38 File Offset: 0x00418D38
		private void CreatePortal(FrameEventData evt)
		{
			this._portal = this.PlaceNPCOnGround(549, this._startPoint + new Vector2(-240f, 0f));
			this._portal.immortal = true;
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0041AB74 File Offset: 0x00418D74
		private void DryadStand(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				this._dryad.ai[0] = 0f;
				this._dryad.ai[1] = (float)evt.Remaining;
			}
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0041ABA8 File Offset: 0x00418DA8
		private void DryadLookRight(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				this._dryad.direction = 1;
				this._dryad.spriteDirection = 1;
			}
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x0041ABCC File Offset: 0x00418DCC
		private void DryadLookLeft(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				this._dryad.direction = -1;
				this._dryad.spriteDirection = -1;
			}
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x0041ABF0 File Offset: 0x00418DF0
		private void DryadWalk(FrameEventData evt)
		{
			this._dryad.ai[0] = 1f;
			this._dryad.ai[1] = 2f;
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x0041AC18 File Offset: 0x00418E18
		private void DryadConfusedEmote(FrameEventData evt)
		{
			if (this._dryad != null && evt.IsFirstFrame)
			{
				EmoteBubble.NewBubble(87, new WorldUIAnchor(this._dryad), evt.Duration);
			}
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x0041AC48 File Offset: 0x00418E48
		private void DryadAlertEmote(FrameEventData evt)
		{
			if (this._dryad != null && evt.IsFirstFrame)
			{
				EmoteBubble.NewBubble(3, new WorldUIAnchor(this._dryad), evt.Duration);
			}
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x0041AC74 File Offset: 0x00418E74
		private void CreateOgre(FrameEventData evt)
		{
			int num = NPC.NewNPC((int)this._portal.Center.X, (int)this._portal.Bottom.Y, 576, 0, 0f, 0f, 0f, 0f, 255);
			this._ogre = Main.npc[num];
			this._ogre.knockBackResist = 0f;
			this._ogre.immortal = true;
			this._ogre.dontTakeDamage = true;
			this._ogre.takenDamageMultiplier = 0f;
			this._ogre.immune[255] = 100000;
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x0041AD24 File Offset: 0x00418F24
		private void OgreStand(FrameEventData evt)
		{
			if (this._ogre != null)
			{
				this._ogre.ai[0] = 0f;
				this._ogre.ai[1] = 0f;
				this._ogre.velocity = Vector2.Zero;
			}
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x0041AD64 File Offset: 0x00418F64
		private void DryadAttack(FrameEventData evt)
		{
			if (this._dryad != null)
			{
				this._dryad.ai[0] = 14f;
				this._dryad.ai[1] = (float)evt.Remaining;
				this._dryad.dryadWard = false;
			}
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x0041ADA4 File Offset: 0x00418FA4
		private void OgreLookRight(FrameEventData evt)
		{
			if (this._ogre != null)
			{
				this._ogre.direction = 1;
				this._ogre.spriteDirection = 1;
			}
		}

		// Token: 0x06001320 RID: 4896 RVA: 0x0041ADC8 File Offset: 0x00418FC8
		private void OgreLookLeft(FrameEventData evt)
		{
			if (this._ogre != null)
			{
				this._ogre.direction = -1;
				this._ogre.spriteDirection = -1;
			}
		}

		// Token: 0x06001321 RID: 4897 RVA: 0x0041ADEC File Offset: 0x00418FEC
		public override void OnBegin()
		{
			Main.NewText("DD2Film: Begin", 255, 255, 255, false);
			Main.dayTime = true;
			Main.time = 27000.0;
			this._startPoint = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY - 32f);
			base.OnBegin();
		}

		// Token: 0x06001322 RID: 4898 RVA: 0x0041AE54 File Offset: 0x00419054
		private NPC PlaceNPCOnGround(int type, Vector2 position)
		{
			int num = (int)position.X;
			int num2 = (int)position.Y;
			int i = num / 16;
			int num3 = num2 / 16;
			while (!WorldGen.SolidTile(i, num3))
			{
				num3++;
			}
			num2 = num3 * 16;
			int start = 100;
			if (type == 20)
			{
				start = 1;
			}
			else if (type == 576)
			{
				start = 50;
			}
			int num4 = NPC.NewNPC(num, num2, type, start, 0f, 0f, 0f, 0f, 255);
			return Main.npc[num4];
		}

		// Token: 0x06001323 RID: 4899 RVA: 0x0041AED8 File Offset: 0x004190D8
		public override void OnEnd()
		{
			if (this._dryad != null)
			{
				this._dryad.active = false;
			}
			if (this._portal != null)
			{
				this._portal.active = false;
			}
			if (this._ogre != null)
			{
				this._ogre.active = false;
			}
			using (List<NPC>.Enumerator enumerator = this._critters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.active = false;
				}
			}
			using (List<NPC>.Enumerator enumerator = this._army.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.active = false;
				}
			}
			Main.NewText("DD2Film: End", 255, 255, 255, false);
			base.OnEnd();
		}

		// Token: 0x04003499 RID: 13465
		private NPC _dryad;

		// Token: 0x0400349A RID: 13466
		private NPC _ogre;

		// Token: 0x0400349B RID: 13467
		private NPC _portal;

		// Token: 0x0400349C RID: 13468
		private List<NPC> _army = new List<NPC>();

		// Token: 0x0400349D RID: 13469
		private List<NPC> _critters = new List<NPC>();

		// Token: 0x0400349E RID: 13470
		private Vector2 _startPoint;
	}
}
