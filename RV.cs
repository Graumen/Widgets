using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static Terraria.Main;
using System;
using Terraria.GameInput;
using Terraria.UI;
using Terraria;
using ReLogic.Graphics;
using Terraria.ModLoader;

namespace Widgets
{
    class RV : UIState
    {
        private static float UIDisplay_LifePerHeart = 20f;
        private static int UIDisplay_ManaPerStar = 20;
        private static int UI_ScreenAnchorX = screenWidth - 800;
        private static int DrawBuffIcon(int drawBuffText, int i, int b, int x, int y)
        {
            if (b == 0)
            {
                return drawBuffText;
            }
            Color color = new Color(buffAlpha[i], buffAlpha[i], buffAlpha[i], buffAlpha[i]);
            spriteBatch.Draw(buffTexture[b], new Vector2(x, y), new Rectangle(0, 0, buffTexture[b].Width, buffTexture[b].Height), color, 0f, default, 1f, SpriteEffects.None, 0f);
            if (!vanityPet[b] && !lightPet[b] && !buffNoTimeDisplay[b] && (!player[myPlayer].honeyWet || b != 48) && (!player[myPlayer].wet || !expertMode || b != 46) && player[myPlayer].buffTime[i] > 2)
            {
                string text = Lang.LocalizedDuration(new TimeSpan(0, 0, player[myPlayer].buffTime[i] / 60), abbreviated: true, showAllAvailableUnits: false);
                DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, fontItemStack, text, new Vector2(x, y + buffTexture[b].Height), color, 0f, default, 0.8f, SpriteEffects.None, 0f);
            }
            if (mouseX < x + buffTexture[b].Width && mouseY < y + buffTexture[b].Height && mouseX > x && mouseY > y)
            {
                drawBuffText = i;
                buffAlpha[i] += 0.1f;
                bool flag = mouseRight && mouseRightRelease;
                if (PlayerInput.UsingGamepad)
                {
                    flag = mouseLeft && mouseLeftRelease && playerInventory;
                    if (playerInventory)
                    {
                        player[myPlayer].mouseInterface = true;
                    }
                }
                else
                {
                    player[myPlayer].mouseInterface = true;
                }
                if (flag)
                {
                    TryRemovingBuff(i, b);
                }
            }
            else
            {
                buffAlpha[i] -= 0.05f;
            }
            if (buffAlpha[i] > 1f)
            {
                buffAlpha[i] = 1f;
            }
            else if (buffAlpha[i] < 0.4)
            {
                buffAlpha[i] = 0.4f;
            }
            if (PlayerInput.UsingGamepad && !playerInventory)
            {
                drawBuffText = -1;
            }
            return drawBuffText;
        }
        private static void DrawInterface_Resources_Breath()
        {
            bool flag = false;
            if (player[myPlayer].dead)
            {
                return;
            }
            if (player[myPlayer].lavaTime < player[myPlayer].lavaMax && player[myPlayer].lavaWet)
            {
                flag = true;
            }
            else if (player[myPlayer].lavaTime < player[myPlayer].lavaMax && player[myPlayer].breath == player[myPlayer].breathMax)
            {
                flag = true;
            }
            Vector2 value = player[myPlayer].Top + new Vector2(0f, player[myPlayer].gfxOffY);
            if (playerInventory && screenHeight < 1000)
            {
                value.Y += player[myPlayer].height - 20;
            }
            value = Vector2.Transform(value - screenPosition, GameViewMatrix.ZoomMatrix);
            if (!playerInventory || screenHeight >= 1000)
            {
                value.Y -= 100f;
            }
            value /= UIScale;
            if (ingameOptionsWindow || InGameUI.IsVisible)
            {
                value = new Vector2(screenWidth / 2, screenHeight / 2 + 236);
                if (InGameUI.IsVisible)
                {
                    value.Y = screenHeight - 64;
                }
            }
            if (player[myPlayer].breath < player[myPlayer].breathMax && !player[myPlayer].ghost && !flag)
            {
                _ = player[myPlayer].breathMax / 20;
                int num18 = 20;
                for (int j = 1; j < player[myPlayer].breathMax / num18 + 1; j++)
                {
                    float num23 = 1f;
                    int num22;
                    if (player[myPlayer].breath >= j * num18)
                    {
                        num22 = 255;
                    }
                    else
                    {
                        float num21 = (player[myPlayer].breath - (j - 1) * num18) / (float)num18;
                        num22 = (int)(30f + 225f * num21);
                        if (num22 < 30)
                        {
                            num22 = 30;
                        }
                        num23 = num21 / 4f + 0.75f;
                        if (num23 < 0.75)
                        {
                            num23 = 0.75f;
                        }
                    }
                    int num20 = 0;
                    int num19 = 0;
                    if (j > 10)
                    {
                        num20 -= 260;
                        num19 += 26;
                    }
                    spriteBatch.Draw(bubbleTexture, value + new Vector2(26 * (j - 1) + num20 - 125f, 32f + (bubbleTexture.Height - bubbleTexture.Height * num23) / 2f + num19), new Rectangle(0, 0, bubbleTexture.Width, bubbleTexture.Height), new Color(num22, num22, num22, num22), 0f, default, num23, SpriteEffects.None, 0f);
                }
            }
            if (!((player[myPlayer].lavaTime < player[myPlayer].lavaMax && !player[myPlayer].ghost) & flag))
            {
                return;
            }
            int num17 = player[myPlayer].lavaMax / 10;
            _ = player[myPlayer].breathMax / num17;
            for (int i = 1; i < player[myPlayer].lavaMax / num17 + 1; i++)
            {
                float num16 = 1f;
                int num15;
                if (player[myPlayer].lavaTime >= i * num17)
                {
                    num15 = 255;
                }
                else
                {
                    float num14 = (player[myPlayer].lavaTime - (i - 1) * num17) / (float)num17;
                    num15 = (int)(30f + 225f * num14);
                    if (num15 < 30)
                    {
                        num15 = 30;
                    }
                    num16 = num14 / 4f + 0.75f;
                    if (num16 < 0.75)
                    {
                        num16 = 0.75f;
                    }
                }
                int num13 = 0;
                int num12 = 0;
                if (i > 10)
                {
                    num13 -= 260;
                    num12 += 26;
                }
                spriteBatch.Draw(flameTexture, value + new Vector2(26 * (i - 1) + num13 - 125f, 32f + (flameTexture.Height - flameTexture.Height * num16) / 2f + num12), new Rectangle(0, 0, bubbleTexture.Width, bubbleTexture.Height), new Color(num15, num15, num15, num15), 0f, default, num16, SpriteEffects.None, 0f);
            }
        }
        private static void DrawInterface_Resources_ClearBuffs()
        {
            buffString = "";
            bannerMouseOver = false;
            if (!recBigList)
            {
                recStart = 0;
            }
        }
        private static void DrawInterface_Resources_Life()
        {
            UIDisplay_LifePerHeart = 20f;
            if (LocalPlayer.ghost)
            {
                return;
            }
            int num17 = player[myPlayer].statLifeMax / 20;
            int num16 = (player[myPlayer].statLifeMax - 400) / 5;
            if (num16 < 0)
            {
                num16 = 0;
            }
            if (num16 > 0)
            {
                num17 = player[myPlayer].statLifeMax / (20 + num16 / 4);
                UIDisplay_LifePerHeart = (float)player[myPlayer].statLifeMax / 20f;
            }
            int num15 = player[myPlayer].statLifeMax2 - player[myPlayer].statLifeMax;
            UIDisplay_LifePerHeart += num15 / num17;
            int num14 = (int)((float)player[myPlayer].statLifeMax2 / UIDisplay_LifePerHeart);
            if (num14 >= 10)
            {
                num14 = 10;
            }
            string text = Lang.inter[0].Value + " " + player[myPlayer].statLifeMax2 + "/" + player[myPlayer].statLifeMax2;
            Vector2 vector = fontMouseText.MeasureString(text);
            if (!player[myPlayer].ghost)
            {
                DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, fontMouseText, Lang.inter[0].Value, new Vector2((float)(500 + 13 * num14) - vector.X * 0.5f + (float)UI_ScreenAnchorX, 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, fontMouseText, player[myPlayer].statLife.ToString() + "/" + player[myPlayer].statLifeMax2.ToString(), new Vector2((float)(500 + 13 * num14) + vector.X * 0.5f + (float)UI_ScreenAnchorX, 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, new Vector2(fontMouseText.MeasureString(player[myPlayer].statLife.ToString() + "/" + player[myPlayer].statLifeMax2.ToString()).X, 0f), 1f, SpriteEffects.None, 0f);
            }
            for (int i = 1; i < (int)((float)player[myPlayer].statLifeMax2 / UIDisplay_LifePerHeart) + 1; i++)
            {
                float num13 = 1f;
                bool flag = false;
                int num12;
                if ((float)player[myPlayer].statLife >= (float)i * UIDisplay_LifePerHeart)
                {
                    num12 = 255;
                    if ((float)player[myPlayer].statLife == (float)i * UIDisplay_LifePerHeart)
                    {
                        flag = true;
                    }
                }
                else
                {
                    float num11 = ((float)player[myPlayer].statLife - (float)(i - 1) * UIDisplay_LifePerHeart) / UIDisplay_LifePerHeart;
                    num12 = (int)(30f + 225f * num11);
                    if (num12 < 30)
                    {
                        num12 = 30;
                    }
                    num13 = num11 / 4f + 0.75f;
                    if ((double)num13 < 0.75)
                    {
                        num13 = 0.75f;
                    }
                    if (num11 > 0f)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    num13 += cursorScale - 1f;
                }
                int num10 = 0;
                int num9 = 0;
                if (i > 10)
                {
                    num10 -= 260;
                    num9 += 26;
                }
                int a = (int)((double)(float)num12 * 0.9);
                if (!player[myPlayer].ghost)
                {
                    if (num16 > 0)
                    {
                        num16--;
                        spriteBatch.Draw(heart2Texture, new Vector2(500 + 26 * (i - 1) + num10 + UI_ScreenAnchorX + heartTexture.Width / 2, 32f + ((float)heartTexture.Height - (float)heartTexture.Height * num13) / 2f + (float)num9 + (float)(heartTexture.Height / 2)), new Rectangle(0, 0, heartTexture.Width, heartTexture.Height), new Color(num12, num12, num12, a), 0f, new Vector2(heartTexture.Width / 2, heartTexture.Height / 2), num13, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(heartTexture, new Vector2(500 + 26 * (i - 1) + num10 + UI_ScreenAnchorX + heartTexture.Width / 2, 32f + ((float)heartTexture.Height - (float)heartTexture.Height * num13) / 2f + (float)num9 + (float)(heartTexture.Height / 2)), new Rectangle(0, 0, heartTexture.Width, heartTexture.Height), new Color(num12, num12, num12, a), 0f, new Vector2(heartTexture.Width / 2, heartTexture.Height / 2), num13, SpriteEffects.None, 0f);
                    }
                }
            }
        }
        private static void DrawInterface_Resources_Mana()
        {
            UIDisplay_ManaPerStar = 20;
            if (LocalPlayer.ghost || player[myPlayer].statManaMax2 <= 0)
            {
                return;
            }
            _ = player[myPlayer].statManaMax2 / 20;
            Vector2 vector = fontMouseText.MeasureString(Lang.inter[2].Value);
            int num7 = 50;
            if (vector.X >= 45f)
            {
                num7 = (int)vector.X + 5;
            }
            DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, fontMouseText, Lang.inter[2].Value, new Vector2(800 - num7 + UI_ScreenAnchorX, 6f), new Color(mouseTextColor, mouseTextColor, mouseTextColor, mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            for (int i = 1; i < player[myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
            {
                bool flag = false;
                float num6 = 1f;
                int num5;
                if (player[myPlayer].statMana >= i * UIDisplay_ManaPerStar)
                {
                    num5 = 255;
                    if (player[myPlayer].statMana == i * UIDisplay_ManaPerStar)
                    {
                        flag = true;
                    }
                }
                else
                {
                    float num4 = (float)(player[myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
                    num5 = (int)(30f + 225f * num4);
                    if (num5 < 30)
                    {
                        num5 = 30;
                    }
                    num6 = num4 / 4f + 0.75f;
                    if ((double)num6 < 0.75)
                    {
                        num6 = 0.75f;
                    }
                    if (num4 > 0f)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    num6 += cursorScale - 1f;
                }
                int a = (int)((double)(float)num5 * 0.9);
                spriteBatch.Draw(manaTexture, new Vector2(775 + UI_ScreenAnchorX, (float)(30 + manaTexture.Height / 2) + ((float)manaTexture.Height - (float)manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Rectangle(0, 0, manaTexture.Width, manaTexture.Height), new Color(num5, num5, num5, a), 0f, new Vector2(manaTexture.Width / 2, manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
            }
        }
        private static void TryRemovingBuff(int i, int b)
        {
            bool flag = false;
            if (!debuff[b] && b != 60 && b != 151)
            {
                if (player[myPlayer].mount.Active && player[myPlayer].mount.CheckBuff(b))
                {
                    player[myPlayer].mount.Dismount(player[myPlayer]);
                    flag = true;
                }
                if (player[myPlayer].miscEquips[0].buffType == b && !player[myPlayer].hideMisc[0])
                {
                    player[myPlayer].hideMisc[0] = true;
                }
                if (player[myPlayer].miscEquips[1].buffType == b && !player[myPlayer].hideMisc[1])
                {
                    player[myPlayer].hideMisc[1] = true;
                }
                PlaySound(12);
                if (!flag)
                {
                    player[myPlayer].DelBuff(i);
                }
            }
        }
        private void DrawInterface_Resources_Buffs()
        {
            recBigList = false;
            int num6 = -1;
            int num5 = 11;
            for (int i = 0; i < Player.MaxBuffs; i++)
            {
                if (player[myPlayer].buffType[i] > 0)
                {
                    int b = player[myPlayer].buffType[i];
                    int x = 32 + i * 38;
                    int num3 = 76;
                    if (i >= num5)
                    {
                        x = 32 + Math.Abs(i % 11) * 38;
                        num3 += 50 * (i / 11);
                    }
                    num6 = DrawBuffIcon(num6, i, b, x, num3);
                }
                else
                {
                    buffAlpha[i] = 0.4f;
                }
            }
            if (num6 < 0)
            {
                return;
            }
            int num4 = player[myPlayer].buffType[num6];
            if (num4 > 0)
            {
                buffString = Lang.GetBuffDescription(num4);
                int rare = 0;
                if (num4 == 26 && expertMode)
                {
                    buffString = Terraria.Localization.Language.GetTextValue("BuffDescription.WellFed_Expert");
                }
                if (num4 == 147)
                {
                    bannerMouseOver = true;
                }
                if (num4 == 94)
                {
                    buffString = string.Concat(str1: ((int)(player[myPlayer].manaSickReduction * 100f) + 1).ToString(), str0: buffString, str2: "%");
                }
                if (meleeBuff[num4])
                {
                    rare = -10;
                }
                BuffLoader.ModifyBuffTip(num4, ref buffString, ref rare);
                instance.MouseTextHackZoom(Lang.GetBuffName(num4), rare, 0);
            }
        }
        private void GUIBarsMouseOverLife()
        {
            if (!mouseText)
            {
                int num3 = 26 * player[myPlayer].statLifeMax2 / (int)UIDisplay_LifePerHeart;
                int num2 = 0;
                if (player[myPlayer].statLifeMax2 > 200)
                {
                    num3 = 260;
                    num2 += 26;
                }
                if (mouseX > 500 + UI_ScreenAnchorX && mouseX < 500 + num3 + UI_ScreenAnchorX && mouseY > 32 && mouseY < 32 + heartTexture.Height + num2)
                {
                    instance.MouseTextHackZoom("");
                    mouseText = true;
                }
            }
        }
        private void GUIBarsMouseOverMana()
        {
            if (!mouseText)
            {
                int num3 = 24;
                int num2 = 28 * player[myPlayer].statManaMax2 / UIDisplay_ManaPerStar;
                if (mouseX > 762 + UI_ScreenAnchorX && mouseX < 762 + num3 + UI_ScreenAnchorX && mouseY > 30 && mouseY < 30 + num2)
                {
                    instance.MouseTextHackZoom("");
                    mouseText = true;
                }
            }
        }
        protected override void DrawSelf(SpriteBatch sb)
        {
            GUIBarsDraw();
            if (!ModContent.GetInstance<Config>().f57)
            {
                GUIBarsMouseOverLife();
                GUIBarsMouseOverMana();
            }
        }
        protected void GUIBarsDrawInner()
        {
            var ci = ModContent.GetInstance<Config>();

            UI_ScreenAnchorX = screenWidth - 800;
            if (ci.f57)
            {
                DrawInterface_Resources_Life();
                DrawInterface_Resources_Mana();
            }
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, UIScaleMatrix);
            if ("Off" == ci.f3) DrawInterface_Resources_Breath();
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, UIScaleMatrix);
            DrawInterface_Resources_ClearBuffs();
            if (!ingameOptionsWindow && !playerInventory && !inFancyUI)
            {
                DrawInterface_Resources_Buffs();
            }
        }
        public void GUIBarsDraw()
        {
            if (ignoreErrors)
            {
                try
                {
                    GUIBarsDrawInner();
                }
                catch (Exception e)
                {
                    TimeLogger.DrawException(e);
                }
            }
            else
            {
                GUIBarsDrawInner();
            }
        }
    }
}