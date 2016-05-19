using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Drawing.Imaging;
using System.IO;
using System.Collections;
//using ICSharpCode.SharpZipLib.Checksums;
//using ICSharpCode.SharpZipLib.Zip;

namespace TransSkin2Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            modeSelect.SelectedIndex = 0;
            outb("生成材质包目录需将已生成的文件和已有皮肤放在相同目录下，会自动识别！");
            outb("皮肤文件名称需要更改为skin.png「粗胳膊」和skin_sin.png「细胳膊」！");
            outb("此外请不要在选择的目录下存放名为temp的文件夹，否则将会被删除！");
        }

        //每个第二层区域所对应的点和宽高：
        /*
         *  x   y Width Height
         * 头部
         *  32  8   8   8   左
         *  40  8   8   8   前
         *  48  8   8   8   右
         *  56  8   8   8   后
         *  40  0   8   8   上
         *  48  0   8   8   下
         * 上衣
         *  16  36  4   12  左
         *  20  36  8   12  前
         *  28  36  4   12  右
         *  32  36  8   12  后
         *  20  32  8   4   上
         *  28  32  8   4   下
         * 左手臂-steve
         *  48  52  4   12  左（内）
         *  52  52  4   12  前
         *  56  52  4   12  右（外）
         *  60  52  4   12  后
         *  52  48  4   4   上
         *  56  48  4   4   下
         * 右手臂-steve
         *  40  36  4   12  左（外）
         *  44  36  4   12  前
         *  48  36  4   12  右（内）
         *  52  36  4   12  后
         *  44  32  4   4   上
         *  48  32  4   4   下
         * 左腿
         *  0   52  4   12  左（内）
         *  4   52  4   12  前
         *  8   52  4   12  右（外）
         *  12  52  4   12  后
         *  4   48  4   4   上
         *  8   48  4   4   下
         * 右腿
         *  0   36  4   12  左（外）
         *  4   36  4   12  前
         *  8   36  4   12  右（内）
         *  12  36  4   12  后
         *  4   32  4   4   上
         *  8   32  4   4   下
         * 左手臂-Alex
         *  40  36  4   12  左（外）
         *  44  36  3   12  前
         *  47  36  4   12  右（内）
         *  51  36  3   12  后
         *  44  32  3   4   上
         *  47  32  3   4   下
         * 右手臂-Alex
         *  48  52  4   12  左（内）
         *  52  52  3   12  前
         *  55  52  4   12  右（外）
         *  59  52  3   12  后
         *  52  48  3   4   上
         *  55  48  3   4   下
         */
        /*
        JArray HeadLeft = (JArray)JsonConvert.DeserializeObject("[32,8,8,8]");
        JArray HeadFront = (JArray)JsonConvert.DeserializeObject("[40,8,8,8]");
        JArray HeadRight = (JArray)JsonConvert.DeserializeObject("[48,8,8,8]");
        JArray HeadBack = (JArray)JsonConvert.DeserializeObject("[56,8,8,8]");
        JArray HeadTop = (JArray)JsonConvert.DeserializeObject("[40,0,8,8]");
        JArray HeadBottom = (JArray)JsonConvert.DeserializeObject("[48,0,8,8]");
        JArray BodyLeft = (JArray)JsonConvert.DeserializeObject("[16,36,4,12]");
        JArray BodyFront = (JArray)JsonConvert.DeserializeObject("[20,36,8,12]");
        JArray BodyRight = (JArray)JsonConvert.DeserializeObject("[32,36,4,12]");
        JArray BodyBack = (JArray)JsonConvert.DeserializeObject("[32,36,8,12]");
        JArray BodyTop = (JArray)JsonConvert.DeserializeObject("[20,32,8,4]");
        JArray BodyBottom = (JArray)JsonConvert.DeserializeObject("[28,32,8,4]");
        JArray SLArmLeft = (JArray)JsonConvert.DeserializeObject("[48,52,4,12]");
        JArray SLArmFront = (JArray)JsonConvert.DeserializeObject("[52,52,4,12]");
        JArray SLArmRight = (JArray)JsonConvert.DeserializeObject("[56,52,4,12]");
        JArray SLArmBack = (JArray)JsonConvert.DeserializeObject("[60,52,4,12]");
        JArray SLArmTop = (JArray)JsonConvert.DeserializeObject("[52,48,4,4]");
        JArray SLArmBottom = (JArray)JsonConvert.DeserializeObject("[56,48,4,4]");
        JArray SRArmLeft = (JArray)JsonConvert.DeserializeObject("[40,36,4,12]");
        JArray SRArmFront = (JArray)JsonConvert.DeserializeObject("[44,36,4,12]");
        JArray SRArmRight = (JArray)JsonConvert.DeserializeObject("[48,36,4,12]");
        JArray SRArmBack = (JArray)JsonConvert.DeserializeObject("[52,36,4,12]");
        JArray SRArmTop = (JArray)JsonConvert.DeserializeObject("[44,32,4,4]");
        JArray SRArmBottom = (JArray)JsonConvert.DeserializeObject("[48,32,4,4]");
        JArray LLegLeft = (JArray)JsonConvert.DeserializeObject("[0,52,4,12]");
        JArray LLegFront = (JArray)JsonConvert.DeserializeObject("[4,52,4,12]");
        JArray LLegRight = (JArray)JsonConvert.DeserializeObject("[8,52,4,12]");
        JArray LLegBack = (JArray)JsonConvert.DeserializeObject("[12,52,4,12]");
        JArray LLegTop = (JArray)JsonConvert.DeserializeObject("[4,48,4,4]");
        JArray LLegBottom = (JArray)JsonConvert.DeserializeObject("[8,48,4,4]");
        JArray RLegLeft = (JArray)JsonConvert.DeserializeObject("[0,36,4,12]");
        JArray RLegFront = (JArray)JsonConvert.DeserializeObject("[4,36,4,12]");
        JArray RLegRight = (JArray)JsonConvert.DeserializeObject("[8,36,4,12]");
        JArray RLegBack = (JArray)JsonConvert.DeserializeObject("[12,36,4,12]");
        JArray RLegTop = (JArray)JsonConvert.DeserializeObject("[4,32,4,4]");
        JArray RLegBottom = (JArray)JsonConvert.DeserializeObject("[8,32,4,4]");
        JArray ALArmLeft = (JArray)JsonConvert.DeserializeObject("[40,36,4,12]");
        JArray ALArmFront = (JArray)JsonConvert.DeserializeObject("[44,36,3,12]");
        JArray ALArmRight = (JArray)JsonConvert.DeserializeObject("[47,36,4,12]");
        JArray ALArmBack = (JArray)JsonConvert.DeserializeObject("[51,36,3,12]");
        JArray ALArmTop = (JArray)JsonConvert.DeserializeObject("[44,32,3,4]");
        JArray ALArmBottom = (JArray)JsonConvert.DeserializeObject("[47,32,3,4]");
        JArray ARArmLeft = (JArray)JsonConvert.DeserializeObject("[48,52,4,12]");
        JArray ARArmFront = (JArray)JsonConvert.DeserializeObject("[52,52,3,12]");
        JArray ARArmRight = (JArray)JsonConvert.DeserializeObject("[55,52,4,12]");
        JArray ARArmBack = (JArray)JsonConvert.DeserializeObject("[59,52,3,12]");
        JArray ARArmTop = (JArray)JsonConvert.DeserializeObject("[52,48,3,4]");
        JArray ARArmBottom = (JArray)JsonConvert.DeserializeObject("[55,48,3,4]");
        */

        private void selectSkinBtn_Click(object sender, EventArgs e)
        {
            bool steveOrAlex = true; //true为Steve4像素手臂，false为Alex3像素手臂。
            bool whichMode = true; //true为1，普通2格高，false为2，大头娃娃1格高。
            bool isMakePack = false; //true为创建材质包目录。
            if (modeSelect.SelectedIndex == 3)
            {
                if (modeSelect.SelectedIndex == 2)
                {
                    whichMode = false;
                }
                if (isAlex.Checked == true)
                {
                    steveOrAlex = false;
                }
                isMakePack = true;
                saveFileFun(isMakePack, whichMode, steveOrAlex, "");
            }
            else if (modeSelect.SelectedIndex == 0)
            {
                MessageBox.Show("错误的模式！");
            }
            else
            {
                OpenFileDialog fdia = new OpenFileDialog();
                fdia.Title = "请选择皮肤文件，注意是64*64的尺寸！";
                fdia.Filter = "PNG图片文件|*.png|所有文件|*.*";
                fdia.RestoreDirectory = true;
                fdia.FilterIndex = 0;
                if (fdia.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fdia.FileName;
                    Bitmap pic = new Bitmap(fileName);
                    if (pic.Width == 64 && pic.Height == 64)
                    {
                        if (isAlex.Checked == true)
                        {
                            steveOrAlex = false;
                        }
                        else
                        {
                            steveOrAlex = true;
                        }
                        //检测选项
                        if (modeSelect.SelectedIndex == 1)
                        {
                            whichMode = true;
                            secondStep(isMakePack, steveOrAlex, whichMode, pic, fileName);
                        }
                        else if (modeSelect.SelectedIndex == 2)
                        {
                            whichMode = false;
                            secondStep(isMakePack, steveOrAlex, whichMode, pic, fileName);
                        }
                        else
                        {
                            outb("错误的模式！程序中断。");
                        }
                    }
                    else
                    {
                        outb("皮肤图片非标准皮肤格式尺寸64*64！");
                    }
                    pic.Dispose();
                }
            }
        }

        /*
            bool[,] hairFront = new bool[8, 8];
            outputBox.Text += "\r\n";
            for (int i = 0; i < hairFront.GetLength(0); i++)
            {
                for (int j = 0; j < hairFront.GetLength(1); j++)
                {
                    if (GetPixelColor(pic, 40 + i, 8 + j) != 0) hairFront[i, j] = true; else hairFront[i, j] = false;
                    //debug out put
                    if (hairFront[i, j] == false)
                    {
                        outputBox.Text += "0";
                    }
                    else
                    {
                        outputBox.Text += "8";
                    }
                }
                outputBox.Text += "\r\n";
            }

            debug output image - 
            Bitmap hairFront = CutImage(pic, new Rectangle(40, 8, 8, 8));
            hairFront.Save(fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            outb(GetPixelColor(hairFront, 0, 0).ToString());
            outb(GetPixelColor(pic, 40, 8).ToString());
         */
        /*
         * JObject
        StringWriter strw = new StringWriter();
        JsonWriter jsw = new JsonTextWriter(strw);
        jsw.WriteStartObject();
        jsw.WritePropertyName("from");
        jsw.WriteValue("abc");
        jsw.WritePropertyName("to");
        byte[] testbyte = {0,1,2};
        jsw.WriteValue(testbyte);
        jsw.WriteEndObject();
        jsw.Flush();
        jsw.Close();
        string jsontexttest = strw.GetStringBuilder().ToString();
         * 
         * JArray
        int[] tempa = { 0, 1, 2 };
        elements.Add(tempa);
        string temp = elements.ToString();
        */
        private void secondStep(bool isMakePack, bool steveOrAlex, bool whichMode, Bitmap pic, string fileName) 
        {
            if (whichMode == false)
            {
                if (MessageBox.Show("这是WIP项目。\r\n现在的算法已经改进了可以使用了不过……不知道哪里出的错误……\r\n我已经跪在地上写代码了怎么还是有问题（╯－＿－）╯╧╧", "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    //Application.Exit();
                }
            }
            //else
            //{
                outputBox.Text = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + "初始化完毕……";
                JObject allText = (JObject)JsonConvert.DeserializeObject("{}");
                if (whichMode == true)
                {
                    if (steveOrAlex == true)
                    {
                        //Steve
                        allText = (JObject)JsonConvert.DeserializeObject(Properties.Resources.SkinJson_Nor);
                    }
                    else
                    {
                        //Alex
                        allText = (JObject)JsonConvert.DeserializeObject(Properties.Resources.SkinJson_Sin);
                    }
                }
                else
                {
                    if (steveOrAlex == true)
                    {
                        //Steve
                        allText = (JObject)JsonConvert.DeserializeObject(Properties.Resources.MiniSkinJson_Nor);
                    }
                    else
                    {
                        //Alex
                        allText = (JObject)JsonConvert.DeserializeObject(Properties.Resources.MiniSkinJson_Sin);
                    }
                }
                string elementsText = allText["elements"].ToString();
                JArray elements = (JArray)JsonConvert.DeserializeObject(elementsText);

                flushElements(pic, elements, steveOrAlex, whichMode);
                allText["elements"] = elements;
                string writeOut = allText.ToString();

                saveFileFun(isMakePack, whichMode, steveOrAlex, writeOut);
            //}
        }

        private void saveFileFun(bool isMakePack, bool whichMode, bool steveOrAlex, string saveStr)
        {
            if (isMakePack)
            {
                //生成材质包目录
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "保存为temp文件夹……请选择父文件夹，将自动生成！";
                if (fbd.ShowDialog() == DialogResult.OK) 
                {
                    if (Directory.Exists(fbd.SelectedPath + "/temp"))
                    {
                        Directory.Delete(fbd.SelectedPath + "/temp", true);
                    }
                    Directory.CreateDirectory(fbd.SelectedPath + "/temp/assets/minecraft/blockstates");
                    Directory.CreateDirectory(fbd.SelectedPath + "/temp/assets/minecraft/models/block");
                    Directory.CreateDirectory(fbd.SelectedPath + "/temp/assets/minecraft/textures/blocks");
                    //生成信息文件
                    File.WriteAllText(fbd.SelectedPath + "/temp/pack.mcmeta", Properties.Resources.packMcmeta, Encoding.ASCII);
                    //生成模型和贴图文件
                    if (File.Exists(fbd.SelectedPath + "/spruce_stairs.json"))
                    {
                        File.WriteAllText(fbd.SelectedPath + "/temp/assets/minecraft/blockstates/spruce_stairs.json", Properties.Resources.blockstats_Nor, Encoding.ASCII);
                        File.Move(fbd.SelectedPath + "/spruce_stairs.json", fbd.SelectedPath + "/temp/assets/minecraft/models/block/spruce_stairs.json");
                    }
                    if (File.Exists(fbd.SelectedPath + "/birch_stairs.json"))
                    {
                        File.WriteAllText(fbd.SelectedPath + "/temp/assets/minecraft/blockstates/birch_stairs.json", Properties.Resources.blockstats_Sin, Encoding.ASCII);
                        File.Move(fbd.SelectedPath + "/birch_stairs.json", fbd.SelectedPath + "/temp/assets/minecraft/models/block/birch_stairs.json");
                    }
                    if (File.Exists(fbd.SelectedPath + "/sandstone_stairs.json"))
                    {
                        File.WriteAllText(fbd.SelectedPath + "/temp/assets/minecraft/blockstates/sandstone_stairs.json", Properties.Resources.blockstats_MiniNor, Encoding.ASCII);
                        File.Move(fbd.SelectedPath + "/sandstone_stairs.json", fbd.SelectedPath + "/temp/assets/minecraft/models/block/sandstone_stairs.json");
                    }
                    if (File.Exists(fbd.SelectedPath + "/jungle_stairs.json"))
                    {
                        File.WriteAllText(fbd.SelectedPath + "/temp/assets/minecraft/blockstates/jungle_stairs.json", Properties.Resources.blockstats_MiniSin, Encoding.ASCII);
                        File.Move(fbd.SelectedPath + "/jungle_stairs.json", fbd.SelectedPath + "/temp/assets/minecraft/models/block/jungle_stairs.json");
                    }
                    //生成皮肤文件
                    if (File.Exists(fbd.SelectedPath + "/skin.png"))
                    {
                        File.Move(fbd.SelectedPath + "/skin.png", fbd.SelectedPath + "/temp/assets/minecraft/textures/blocks/skin.png");
                    }
                    else
                    {
                        Bitmap skinNor = new Bitmap(Properties.Resources.skin);
                        skinNor.Save(fbd.SelectedPath + "/temp/assets/minecraft/textures/blocks/skin.png");
                        skinNor.Dispose();
                    }
                    if (File.Exists(fbd.SelectedPath + "/skin_sin.png"))
                    {
                        File.Move(fbd.SelectedPath + "/skin_sin.png", fbd.SelectedPath + "/temp/assets/minecraft/textures/blocks/skin_sin.png");
                    }
                    else
                    {
                        Bitmap skinSin = new Bitmap(Properties.Resources.skin_sin);
                        skinSin.Save(fbd.SelectedPath + "/temp/assets/minecraft/textures/blocks/skin_sin.png");
                        skinSin.Dispose();
                    }
                    //压缩文件
                    //ZipHelper zip = new ZipHelper();
                    //zip.ZipFileDirectory(fbd.SelectedPath + "/temp", fbd.SelectedPath + "/resources.zip");
                    //删除temp文件夹
                    //Directory.Delete(fbd.SelectedPath + "/temp", true);
                    MessageBox.Show("您选择的路径：" + fbd.SelectedPath + "\r\n下现有一个名为temp的文件夹，可直接放置mc材质目录下，或压缩后放置即可，可以改名。", "保存好了……", MessageBoxButtons.OK);
                    MessageBox.Show("更改皮肤材质的方法：\r\n将皮肤改名并放于材质包目录下，皮肤名称如下：\r\n\tSteve版4像素粗胳膊：改名为skin.png\r\n\tAlex版3像素细胳膊：改名为skin_sin.png\r\n材质包目录如下：\r\n\t\\assets\\minecraft\\textures\\blocks下即可。", "保存好了……", MessageBoxButtons.OK);
                }
            }
            else
            {
                //生成普通文件
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "保存为json文件……请选择文件夹，将自动生成文件！";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    if (whichMode)
                    {
                        //普通两格高
                        if (steveOrAlex)
                        {
                            //steve
                            File.WriteAllText(fbd.SelectedPath + "/spruce_stairs.json", saveStr, Encoding.ASCII);
                        }
                        else
                        {
                            //alex
                            File.WriteAllText(fbd.SelectedPath + "/birch_stairs.json", saveStr, Encoding.ASCII);
                        }
                    }
                    else
                    {
                        //大头娃娃
                        if (steveOrAlex)
                        {
                            //steve
                            File.WriteAllText(fbd.SelectedPath + "/sandstone_stairs.json", saveStr, Encoding.ASCII);
                        }
                        else
                        {
                            //alex
                            File.WriteAllText(fbd.SelectedPath + "/jungle_stairs.json", saveStr, Encoding.ASCII);
                        }
                    }
                }
            }
        }

        private void flushElements(Bitmap pic, JArray elements, bool steveOrAlex, bool whichMode )
        {
            ArrayList HeadLeft = returnAFaceFromSkin(pic, "HeadLeft", whichMode);
            ArrayList HeadFront = returnAFaceFromSkin(pic, "HeadFront", whichMode);
            ArrayList HeadRight = returnAFaceFromSkin(pic, "HeadRight", whichMode);
            ArrayList HeadBack = returnAFaceFromSkin(pic, "HeadBack", whichMode);
            ArrayList HeadTop = returnAFaceFromSkin(pic, "HeadTop", whichMode);
            ArrayList HeadBottom = returnAFaceFromSkin(pic, "HeadBottom", whichMode);
            ArrayList BodyLeft = returnAFaceFromSkin(pic, "BodyLeft", whichMode);
            ArrayList BodyFront = returnAFaceFromSkin(pic, "BodyFront", whichMode);
            ArrayList BodyRight = returnAFaceFromSkin(pic, "BodyRight", whichMode);
            ArrayList BodyBack = returnAFaceFromSkin(pic, "BodyBack", whichMode);
            ArrayList BodyTop = returnAFaceFromSkin(pic, "BodyTop", whichMode);
            ArrayList BodyBottom = returnAFaceFromSkin(pic, "BodyBottom", whichMode);
            ArrayList LArmLeft;
            ArrayList LArmFront;
            ArrayList LArmRight;
            ArrayList LArmBack;
            ArrayList LArmTop;
            ArrayList LArmBottom;
            ArrayList RArmLeft;
            ArrayList RArmFront;
            ArrayList RArmRight;
            ArrayList RArmBack;
            ArrayList RArmTop;
            ArrayList RArmBottom;
            if (steveOrAlex == true)
            {
                //steve
                LArmLeft = returnAFaceFromSkin(pic, "SLArmLeft", whichMode);
                LArmFront = returnAFaceFromSkin(pic, "SLArmFront", whichMode);
                LArmRight = returnAFaceFromSkin(pic, "SLArmRight", whichMode);
                LArmBack = returnAFaceFromSkin(pic, "SLArmBack", whichMode);
                LArmTop = returnAFaceFromSkin(pic, "SLArmTop", whichMode);
                LArmBottom = returnAFaceFromSkin(pic, "SLArmBottom", whichMode);
                RArmLeft = returnAFaceFromSkin(pic, "SRArmLeft", whichMode);
                RArmFront = returnAFaceFromSkin(pic, "SRArmFront", whichMode);
                RArmRight = returnAFaceFromSkin(pic, "SRArmRight", whichMode);
                RArmBack = returnAFaceFromSkin(pic, "SRArmBack", whichMode);
                RArmTop = returnAFaceFromSkin(pic, "SRArmTop", whichMode);
                RArmBottom = returnAFaceFromSkin(pic, "SRArmBottom", whichMode);
            }
            else
            {
                //alex
                LArmLeft = returnAFaceFromSkin(pic, "ALArmLeft", whichMode);
                LArmFront = returnAFaceFromSkin(pic, "ALArmFront", whichMode);
                LArmRight = returnAFaceFromSkin(pic, "ALArmRight", whichMode);
                LArmBack = returnAFaceFromSkin(pic, "ALArmBack", whichMode);
                LArmTop = returnAFaceFromSkin(pic, "ALArmTop", whichMode);
                LArmBottom = returnAFaceFromSkin(pic, "ALArmBottom", whichMode);
                RArmLeft = returnAFaceFromSkin(pic, "ARArmLeft", whichMode);
                RArmFront = returnAFaceFromSkin(pic, "ARArmFront", whichMode);
                RArmRight = returnAFaceFromSkin(pic, "ARArmRight", whichMode);
                RArmBack = returnAFaceFromSkin(pic, "ARArmBack", whichMode);
                RArmTop = returnAFaceFromSkin(pic, "ARArmTop", whichMode);
                RArmBottom = returnAFaceFromSkin(pic, "ARArmBottom", whichMode);
            }
            ArrayList LLegLeft = returnAFaceFromSkin(pic, "LLegLeft", whichMode);
            ArrayList LLegFront = returnAFaceFromSkin(pic, "LLegFront", whichMode);
            ArrayList LLegRight = returnAFaceFromSkin(pic, "LLegRight", whichMode);
            ArrayList LLegBack = returnAFaceFromSkin(pic, "LLegBack", whichMode);
            ArrayList LLegTop = returnAFaceFromSkin(pic, "LLegTop", whichMode);
            ArrayList LLegBottom = returnAFaceFromSkin(pic, "LLegBottom", whichMode);
            ArrayList RLegLeft = returnAFaceFromSkin(pic, "RLegLeft", whichMode);
            ArrayList RLegFront = returnAFaceFromSkin(pic, "RLegFront", whichMode);
            ArrayList RLegRight = returnAFaceFromSkin(pic, "RLegRight", whichMode);
            ArrayList RLegBack = returnAFaceFromSkin(pic, "RLegBack", whichMode);
            ArrayList RLegTop = returnAFaceFromSkin(pic, "RLegTop", whichMode);
            ArrayList RLegBottom = returnAFaceFromSkin(pic, "RLegBottom", whichMode);

            if (osHeadLeft.Checked) flushElements(elements, HeadLeft);
            if (osHeadFront.Checked) flushElements(elements, HeadFront);
            if (osHeadRight.Checked) flushElements(elements, HeadRight);
            if (osHeadBack.Checked) flushElements(elements, HeadBack);
            if (osHeadTop.Checked) flushElements(elements, HeadTop);
            if (osHeadBottom.Checked) flushElements(elements, HeadBottom);

            if (osBodyLeft.Checked) flushElements(elements, BodyLeft);
            if (osBodyFront.Checked) flushElements(elements, BodyFront);
            if (osBodyRight.Checked) flushElements(elements, BodyRight);
            if (osBodyBack.Checked) flushElements(elements, BodyBack);
            if (osBodyTop.Checked) flushElements(elements, BodyTop);
            if (osBodyBottom.Checked) flushElements(elements, BodyBottom);

            if (osLArmLeft.Checked) flushElements(elements, LArmLeft);
            if (osLArmFront.Checked) flushElements(elements, LArmFront);
            if (osLArmRight.Checked) flushElements(elements, LArmRight);
            if (osLArmBack.Checked) flushElements(elements, LArmBack);
            if (osLArmTop.Checked) flushElements(elements, LArmTop);
            if (osLArmBottom.Checked) flushElements(elements, LArmBottom);

            if (osRArmLeft.Checked) flushElements(elements, RArmLeft);
            if (osRArmFront.Checked) flushElements(elements, RArmFront);
            if (osRArmRight.Checked) flushElements(elements, RArmRight);
            if (osRArmBack.Checked) flushElements(elements, RArmBack);
            if (osRArmTop.Checked) flushElements(elements, RArmTop);
            if (osRArmBottom.Checked) flushElements(elements, RArmBottom);

            if (osLLegLeft.Checked) flushElements(elements, LLegLeft);
            if (osLLegFront.Checked) flushElements(elements, LLegFront);
            if (osLLegRight.Checked) flushElements(elements, LLegRight);
            if (osLLegBack.Checked) flushElements(elements, LLegBack);
            if (osLLegTop.Checked) flushElements(elements, LLegTop);
            if (osLLegBottom.Checked) flushElements(elements, LLegBottom);

            if (osRLegLeft.Checked) flushElements(elements, RLegLeft);
            if (osRLegFront.Checked) flushElements(elements, RLegFront);
            if (osRLegRight.Checked) flushElements(elements, RLegRight);
            if (osRLegBack.Checked) flushElements(elements, RLegBack);
            if (osRLegTop.Checked) flushElements(elements, RLegTop);
            if (osRLegBottom.Checked) flushElements(elements, RLegBottom);
        }

        private void flushElements(JArray elements, ArrayList arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                elements.Add(arr[i]);
            }
        }

        private double[] backIndex(string whichFace, bool whichMode)
        {
            if (whichMode == true)
            {
                //Normal Model Size
                switch (whichFace)
                {
                    //{贴图x，y，h，w，模型坐标x，y，z，皮肤点x，y，皮肤贴图宽度，皮肤贴图高度}
                    case "HeadLeft":
                        double[] HeadLeft = { 8, 2, 8.25, 2.25, 3, 30.5, 4, 32, 8, 8, 8 };
                        return HeadLeft;
                    case "HeadFront":
                        double[] HeadFront = { 10, 2, 10.25, 2.25, 4, 30.5, 12, 40, 8, 8, 8 };
                        return HeadFront;
                    case "HeadRight":
                        double[] HeadRight = { 12, 2, 12.25, 2.25, 12, 30.5, 11, 48, 8, 8, 8 };
                        return HeadRight;
                    case "HeadBack":
                        double[] HeadBack = { 14, 2, 14.25, 2.25, 11, 30.5, 3, 56, 8, 8, 8 };
                        return HeadBack;
                    case "HeadTop":
                        double[] HeadTop = { 10, 0, 10.25, 0.25, 4, 31, 4, 40, 0, 8, 8 };
                        return HeadTop;
                    case "HeadBottom":
                        double[] HeadBottom = { 12, 0, 12.25, 0.25, 11, 22.5, 4, 48, 0, 8, 8 };
                        return HeadBottom;
                    case "BodyLeft":
                        double[] BodyLeft = { 4, 9, 4.25, 9.25, 3, 22.5, 6, 16, 36, 4, 12 };
                        return BodyLeft;
                    case "BodyFront":
                        double[] BodyFront = { 5, 9, 5.25, 9.25, 4, 22.5, 10, 20, 36, 8, 12 };
                        return BodyFront;
                    case "BodyRight":
                        double[] BodyRight = { 7, 9, 7.25, 9.25, 12, 22.5, 9, 28, 36, 4, 12 };
                        return BodyRight;
                    case "BodyBack":
                        double[] BodyBack = { 8, 9, 8.25, 9.25, 11, 22.5, 5, 32, 36, 8, 12 };
                        return BodyBack;
                    case "BodyTop":
                        double[] BodyTop = { 5, 8, 5.25, 8.25, 4, 23.5, 6, 20, 32, 8, 4 };
                        return BodyTop;
                    case "BodyBottom":
                        double[] BodyBottom = { 7, 8, 7.25, 8.25, 11, 11.5, 6, 28, 32, 8, 4 };
                        return BodyBottom;
                    case "SLArmLeft":
                        double[] SLArmLeft = { 12, 13, 12.25, 13.25, 11, 22.5, 6, 48, 52, 4, 12 };
                        return SLArmLeft;
                    case "SLArmFront":
                        double[] SLArmFront = { 13, 13, 13.25, 13.25, 12, 22.5, 10, 52, 52, 4, 12 };
                        return SLArmFront;
                    case "SLArmRight":
                        double[] SLArmRight = { 14, 13, 14.25, 13.25, 16, 22.5, 9, 56, 52, 4, 12 };
                        return SLArmRight;
                    case "SLArmBack":
                        double[] SLArmBack = { 15, 13, 15.25, 13.25, 15, 22.5, 5, 60, 52, 4, 12 };
                        return SLArmBack;
                    case "SLArmTop":
                        double[] SLArmTop = { 13, 12, 13.25, 12.25, 12, 23.5, 6, 52, 48, 4, 4 };
                        return SLArmTop;
                    case "SLArmBottom":
                        double[] SLArmBottom = { 14, 12, 14.25, 12.25, 15, 10.5, 6, 56, 48, 4, 4 };
                        return SLArmBottom;
                    case "SRArmLeft":
                        double[] SRArmLeft = { 10, 9, 10.25, 9.25, -1, 22.5, 6, 40, 36, 4, 12 };
                        return SRArmLeft;
                    case "SRArmFront":
                        double[] SRArmFront = { 11, 9, 11.25, 9.25, 0, 22.5, 10, 44, 36, 4, 12 };
                        return SRArmFront;
                    case "SRArmRight":
                        double[] SRArmRight = { 12, 9, 12.25, 9.25, 4, 22.5, 9, 48, 36, 4, 12 };
                        return SRArmRight;
                    case "SRArmBack":
                        double[] SRArmBack = { 13, 9, 13.25, 9.25, 3, 22.5, 5, 52, 36, 4, 12 };
                        return SRArmBack;
                    case "SRArmTop":
                        double[] SRArmTop = { 11, 8, 11.25, 8.25, 0, 23.5, 6, 44, 32, 4, 4 };
                        return SRArmTop;
                    case "SRArmBottom":
                        double[] SRArmBottom = { 12, 8, 12.25, 8.25, 3, 10.5, 6, 48, 32, 4, 4 };
                        return SRArmBottom;
                    case "LLegLeft":
                        double[] LLegLeft = { 0, 13, 0.25, 13.25, 7, 10.5, 6, 0, 52, 4, 12 };
                        return LLegLeft;
                    case "LLegFront":
                        double[] LLegFront = { 1, 13, 1.25, 13.25, 8, 10.5, 10, 4, 52, 4, 12 };
                        return LLegFront;
                    case "LLegRight":
                        double[] LLegRight = { 2, 13, 2.25, 13.25, 12, 10.5, 9, 8, 52, 4, 12 };
                        return LLegRight;
                    case "LLegBack":
                        double[] LLegBack = { 3, 13, 3.25, 13.25, 11, 10.5, 5, 12, 52, 4, 12 };
                        return LLegBack;
                    case "LLegTop":
                        double[] LLegTop = { 1, 12, 1.25, 12.25, 8, 11.5, 6, 4, 48, 4, 4 };
                        return LLegTop;
                    case "LLegBottom":
                        double[] LLegBottom = { 2, 12, 2.25, 12.25, 11, -1.5, 6, 8, 48, 4, 4 };
                        return LLegBottom;
                    case "RLegLeft":
                        double[] RLegLeft = { 0, 9, 0.25, 9.25, 3, 10.5, 6, 0, 36, 4, 12 };
                        return RLegLeft;
                    case "RLegFront":
                        double[] RLegFront = { 1, 9, 1.25, 9.25, 4, 10.5, 10, 4, 36, 4, 12 };
                        return RLegFront;
                    case "RLegRight":
                        double[] RLegRight = { 2, 9, 2.25, 9.25, 8, 10.5, 9, 8, 36, 4, 12 };
                        return RLegRight;
                    case "RLegBack":
                        double[] RLegBack = { 3, 9, 3.25, 9.25, 7, 10.5, 5, 12, 36, 4, 12 };
                        return RLegBack;
                    case "RLegTop":
                        double[] RLegTop = { 1, 8, 1.25, 8.25, 4, 11.5, 6, 4, 32, 4, 4 };
                        return RLegTop;
                    case "RLegBottom":
                        double[] RLegBottom = { 2, 8, 2.25, 8.25, 7, -1.5, 6, 8, 32, 4, 4 };
                        return RLegBottom;
                    case "ALArmLeft":
                        double[] ALArmLeft = { 12, 13, 12.25, 13.25, 11, 22.5, 6, 48, 52, 4, 12 };
                        return ALArmLeft;
                    case "ALArmFront":
                        double[] ALArmFront = { 13, 13, 13.25, 13.25, 12, 22.5, 10, 52, 52, 3, 12 };
                        return ALArmFront;
                    case "ALArmRight":
                        double[] ALArmRight = { 13.75, 13, 14, 13.25, 15, 22.5, 9, 55, 52, 4, 12 };
                        return ALArmRight;
                    case "ALArmBack":
                        double[] ALArmBack = { 14.75, 13, 15, 13.25, 14, 22.5, 5, 59, 52, 3, 12 };
                        return ALArmBack;
                    case "ALArmTop":
                        double[] ALArmTop = { 13, 12, 13.25, 12.25, 12, 23.5, 6, 52, 48, 3, 4 };
                        return ALArmTop;
                    case "ALArmBottom":
                        double[] ALArmBottom = { 13.75, 12, 14, 12.25, 14, 10.5, 6, 55, 48, 3, 4 };
                        return ALArmBottom;
                    case "ARArmLeft":
                        double[] ARArmLeft = { 10, 9, 10.25, 9.25, 0, 22.5, 6, 40, 36, 4, 12 };
                        return ARArmLeft;
                    case "ARArmFront":
                        double[] ARArmFront = { 11, 9, 11.25, 9.25, 1, 22.5, 10, 44, 36, 3, 12 };
                        return ARArmFront;
                    case "ARArmRight":
                        double[] ARArmRight = { 11.75, 9, 12, 9.25, 4, 22.5, 9, 47, 36, 4, 12 };
                        return ARArmRight;
                    case "ARArmBack":
                        double[] ARArmBack = { 12.75, 9, 13, 9.25, 3, 22.5, 5, 51, 36, 3, 12 };
                        return ARArmBack;
                    case "ARArmTop":
                        double[] ARArmTop = { 11, 8, 11.25, 8.25, 1, 23.5, 6, 44, 32, 3, 4 };
                        return ARArmTop;
                    case "ARArmBottom":
                        double[] ARArmBottom = { 11.75, 8, 12, 8.25, 3, 10.5, 6, 47, 32, 3, 4 };
                        return ARArmBottom;
                    default:
                        double[] defaultb = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        return defaultb;
                }
            }
            else
            {
                //Big Head Model Size
                switch (whichFace)
                {
                    //{贴图x，y，h，w，模型坐标x，y，z，皮肤点x，y，皮肤贴图宽度，皮肤贴图高度，模型最大值x，y，z}
                    //[11,12,13] - [4,5,6] = 模型坐标变化范围
                    case "HeadLeft":
                        double[] HeadLeft = { 8, 2, 8.25, 2.25, 2, 17, 3, 32, 8, 8, 8, 2, 8, 12 };
                        return HeadLeft;
                    case "HeadFront":
                        double[] HeadFront = { 10, 2, 10.25, 2.25, 3, 17, 13, 40, 8, 8, 8, 12, 8, 13 };
                        return HeadFront;
                    case "HeadRight":
                        double[] HeadRight = { 12, 2, 12.25, 2.25, 13, 17, 3, 48, 8, 8, 8, 13, 8, 12 };
                        return HeadRight;
                    case "HeadBack": //fix 14 -> 15.75 14.25 -> 16
                        double[] HeadBack = { 15.75, 2, 16, 2.25, 3, 17, 2, 56, 8, 8, 8, 12, 8, 2 };
                        return HeadBack;
                    case "HeadTop":
                        double[] HeadTop = { 10, 0, 10.25, 0.25, 3, 18, 3, 40, 0, 8, 8, 12, 18, 12 };
                        return HeadTop;
                    case "HeadBottom":
                        double[] HeadBottom = { 12, 0, 12.25, 0.25, 3, 7, 3, 48, 0, 8, 8, 12, 7, 12 };
                        return HeadBottom;
                    case "BodyLeft":
                        double[] BodyLeft = { 4, 9, 4.25, 9.25, 5, 7, 7, 16, 36, 4, 12, 5, 2, 8 };
                        return BodyLeft;
                    case "BodyFront":
                        double[] BodyFront = { 5, 9, 5.25, 9.25, 6, 7, 9, 20, 36, 8, 12, 9, 2, 9 };
                        return BodyFront;
                    case "BodyRight":
                        double[] BodyRight = { 7, 9, 7.25, 9.25, 10, 7, 7, 28, 36, 4, 12, 10, 2, 8 };
                        return BodyRight;
                    case "BodyBack": //fix
                        double[] BodyBack = { 9.75, 9, 10, 9.25, 6, 7, 6, 32, 36, 8, 12, 10, 3, 7 };
                        return BodyBack;
                    case "BodyTop":
                        double[] BodyTop = { 5, 8, 5.25, 8.25, 6, 8, 7, 20, 32, 8, 4, 9, 8, 8 };
                        return BodyTop;
                    case "BodyBottom":
                        double[] BodyBottom = { 7, 8, 7.25, 8.25, 6, 1, 7, 28, 32, 8, 4, 9, 1, 8 };
                        return BodyBottom;
                    case "SLArmLeft":
                        double[] SLArmLeft = { 12, 13, 12.25, 13.25, 9, 7, 7, 48, 52, 4, 12, 9, 3, 8 };
                        return SLArmLeft;
                    case "SLArmFront":
                        double[] SLArmFront = { 13, 13, 13.25, 13.25, 10, 7, 9, 52, 52, 4, 12, 11, 3, 9 };
                        return SLArmFront;
                    case "SLArmRight":
                        double[] SLArmRight = { 14, 13, 14.25, 13.25, 12, 7, 7, 56, 52, 4, 12, 12, 3, 8 };
                        return SLArmRight;
                    case "SLArmBack": //fix
                        double[] SLArmBack = { 16.75, 13, 17, 13.25, 10, 7, 6, 60, 52, 4, 12, 11, 3, 6 };
                        return SLArmBack;
                    case "SLArmTop":
                        double[] SLArmTop = { 13, 12, 13.25, 12.25, 10, 8, 7, 52, 48, 4, 4, 11, 8, 8 };
                        return SLArmTop;
                    case "SLArmBottom":
                        double[] SLArmBottom = { 14, 12, 14.25, 12.25, 10, 2, 7, 56, 48, 4, 4, 11, 2, 8 };
                        return SLArmBottom;
                    case "SRArmLeft":
                        double[] SRArmLeft = { 10, 9, 10.25, 9.25, 3, 7, 7, 40, 36, 4, 12, 3, 3, 8 };
                        return SRArmLeft;
                    case "SRArmFront":
                        double[] SRArmFront = { 11, 9, 11.25, 9.25, 4, 7, 9, 44, 36, 4, 12, 5, 3, 9 };
                        return SRArmFront;
                    case "SRArmRight":
                        double[] SRArmRight = { 12, 9, 12.25, 9.25, 6, 7, 7, 48, 36, 4, 12, 6, 3, 8 };
                        return SRArmRight;
                    case "SRArmBack": //fix
                        double[] SRArmBack = { 14.75, 9, 15, 9.25, 4, 7, 6, 52, 36, 4, 12, 5, 3, 6 };
                        return SRArmBack;
                    case "SRArmTop":
                        double[] SRArmTop = { 11, 8, 11.25, 8.25, 4, 8, 7, 44, 32, 4, 4, 5, 8, 8 };
                        return SRArmTop;
                    case "SRArmBottom":
                        double[] SRArmBottom = { 12, 8, 12.25, 8.25, 4, 2, 7, 48, 32, 4, 4, 5, 2, 8 };
                        return SRArmBottom;
                    case "LLegLeft":
                        double[] LLegLeft = { 0, 13, 0.25, 13.25, 7, 1, 7, 0, 52, 4, 12, 7, 0, 8 };
                        return LLegLeft;
                    case "LLegFront":
                        double[] LLegFront = { 1, 13, 1.25, 13.25, 8, 1, 9, 4, 52, 4, 12, 9, 0, 9 };
                        return LLegFront;
                    case "LLegRight":
                        double[] LLegRight = { 2, 13, 2.25, 13.25, 10, 1, 7, 8, 52, 4, 12, 10, 0, 8 };
                        return LLegRight;
                    case "LLegBack": //fix
                        double[] LLegBack = { 4.75, 13, 5, 13.25, 8, 1, 6, 12, 52, 4, 12, 9, 0, 6 };
                        return LLegBack;
                    case "LLegTop":
                        double[] LLegTop = { 1, 12, 1.25, 12.25, 8, 2, 7, 4, 48, 4, 4, 9, 2, 8 };
                        return LLegTop;
                    case "LLegBottom":
                        double[] LLegBottom = { 2, 12, 2.25, 12.25, 8, -1, 7, 8, 48, 4, 4, 9, -1, 8 };
                        return LLegBottom;
                    case "RLegLeft":
                        double[] RLegLeft = { 0, 9, 0.25, 9.25, 5, 1, 7, 0, 36, 4, 12, 5, 0, 8 };
                        return RLegLeft;
                    case "RLegFront":
                        double[] RLegFront = { 1, 9, 1.25, 9.25, 6, 1, 9, 4, 36, 4, 12, 7, 0, 9 };
                        return RLegFront;
                    case "RLegRight":
                        double[] RLegRight = { 2, 9, 2.25, 9.25, 8, 1, 7, 8, 36, 4, 12, 8, 0, 8 };
                        return RLegRight;
                    case "RLegBack": //fix
                        double[] RLegBack = { 4.75, 9, 5, 9.25, 6, 1, 6, 12, 36, 4, 12, 7, 0, 6 };
                        return RLegBack;
                    case "RLegTop":
                        double[] RLegTop = { 1, 8, 1.25, 8.25, 6, 2, 7, 4, 32, 4, 4, 7, 2, 8 };
                        return RLegTop;
                    case "RLegBottom":
                        double[] RLegBottom = { 2, 8, 2.25, 8.25, 6, -1, 7, 8, 32, 4, 4, 7, -1, 8 };
                        return RLegBottom;
                    case "ALArmLeft":
                        double[] ALArmLeft = { 12, 13, 12.25, 13.25, 9, 7, 7, 48, 52, 4, 12, 9, 3, 8 };
                        return ALArmLeft;
                    case "ALArmFront":
                        double[] ALArmFront = { 13, 13, 13.25, 13.25, 10, 7, 9, 52, 52, 3, 12, 10, 3, 9 };
                        return ALArmFront;
                    case "ALArmRight":
                        double[] ALArmRight = { 13.75, 13, 14, 13.25, 11, 7, 7, 55, 52, 4, 12, 11, 3, 8 };
                        return ALArmRight;
                    case "ALArmBack": //fix
                        double[] ALArmBack = { 16.5, 13, 16.75, 13.25, 10, 7, 6, 59, 52, 3, 12, 10, 3, 6 };
                        return ALArmBack;
                    case "ALArmTop":
                        double[] ALArmTop = { 13, 12, 13.25, 12.25, 10, 8, 7, 52, 48, 3, 4, 10, 8, 8 };
                        return ALArmTop;
                    case "ALArmBottom":
                        double[] ALArmBottom = { 13.75, 12, 14, 12.25, 10, 2, 7, 55, 48, 3, 4, 10, 2, 8 };
                        return ALArmBottom;
                    case "ARArmLeft":
                        double[] ARArmLeft = { 10, 9, 10.25, 9.25, 4, 7, 7, 40, 36, 4, 12, 4, 3, 8 };
                        return ARArmLeft;
                    case "ARArmFront":
                        double[] ARArmFront = { 11, 9, 11.25, 9.25, 5, 7, 9, 44, 36, 3, 12, 5, 3, 9 };
                        return ARArmFront;
                    case "ARArmRight":
                        double[] ARArmRight = { 11.75, 9, 12, 9.25, 6, 7, 7, 47, 36, 4, 12, 6, 3, 8 };
                        return ARArmRight;
                    case "ARArmBack": //fix
                        double[] ARArmBack = { 14.5, 9, 14.75, 9.25, 5, 7, 6, 51, 36, 3, 12, 5, 3, 6 };
                        return ARArmBack;
                    case "ARArmTop":
                        double[] ARArmTop = { 11, 8, 11.25, 8.25, 5, 8, 7, 44, 32, 3, 4, 5, 8, 8 };
                        return ARArmTop;
                    case "ARArmBottom":
                        double[] ARArmBottom = { 11.75, 8, 12, 8.25, 5, 2, 7, 47, 32, 3, 4, 5, 2, 8 };
                        return ARArmBottom;
                    default:
                        double[] defaultb = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        return defaultb;
                }
            }
        }

        private JObject getAFace(string whichFace, int Width, int Height, bool whichMode)  //0-7
        {
            //第二层的突出像素数
            double secLayerOut = 0.5d;
            secLayerOut = double.Parse(secondLayerOut.Value.ToString());

            double[] index = backIndex(whichFace, whichMode);
            //uv
            double imageX = index[0] + (Width - index[7]) * 0.25, imageY = index[1] + (Height - index[8]) * 0.25, imageH = index[2] + (Width - index[7]) * 0.25, imageW = index[3] + (Height - index[8]) * 0.25;
            string uv = "\"uv\": [" + imageX + "," + imageY + "," + imageH + "," + imageW + "],\"texture\": \"#skin\"";
            //model
            string passStr = whichFace.Substring(whichFace.Length - 3, 3);
            double fromX = 0, fromY = 0, fromZ = 0;
            double toX = fromX + 1, toY = fromY + 1, toZ = fromZ + 1;
            if (whichMode == true)
            {
                //Normal Model Size
                if (passStr == "eft")
                {
                    //左侧
                    fromX = index[4] + secLayerOut;
                    fromY = index[5] - (Height - index[8]);
                    fromZ = index[6] + (Width - index[7]);
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
                else if (passStr == "ont")
                {
                    //前面
                    fromX = index[4] + (Width - index[7]);
                    fromY = index[5] - (Height - index[8]);
                    fromZ = index[6] - secLayerOut;
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
                else if (passStr == "ght")
                {
                    //右侧
                    fromX = index[4] - secLayerOut;
                    fromY = index[5] - (Height - index[8]);
                    fromZ = index[6] - (Width - index[7]);
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
                else if (passStr == "ack")
                {
                    //背面
                    fromX = index[4] - (Width - index[7]);
                    fromY = index[5] - (Height - index[8]);
                    fromZ = index[6] + secLayerOut;
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
                else if (passStr == "Top")
                {
                    //顶部
                    fromX = index[4] + (Width - index[7]);
                    fromY = index[5];
                    fromZ = index[6] + (Height - index[8]);
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
                else if (passStr == "tom")
                {
                    //底部
                    fromX = index[4] - (Height - index[8]);
                    fromY = index[5] + secLayerOut;
                    fromZ = index[6] + (Width - index[7]);
                    toX = fromX + 1;
                    toY = fromY + 1;
                    toZ = fromZ + 1;
                }
            }
            else
            {
                //Big Head Model Size
                //(index[11|12|13] - index[4|5|6] + 1)模型变化范围 / index[9|10]皮肤贴图宽高范围 = 每格像素所占大小:size
                //index[4|5|6]基础模型坐标 + sizeX|Y|Z每像素单位占模型大小 * (Width - index[7]|Height - index[8])第几个像素 = from
                //from + size * (Width - index[7]|Height - index[8])第几个像素 = to
                if (passStr == "eft")
                {
                    //左侧
                    double sizeX = secLayerOut;
                    double sizeY = (Math.Abs(index[12] - index[5]) + 1) / index[10];
                    double sizeZ = (Math.Abs(index[13] - index[6]) + 1) / index[9];
                    fromX = index[4] + (1 - sizeX);
                    fromY = index[5] - sizeY * (Height - index[8]);
                    fromZ = index[6] + sizeZ * (Width - index[7]);
                    toX = fromX + sizeX;
                    toY = fromY + sizeY;
                    toZ = fromZ + sizeZ;
                }
                else if (passStr == "ont")
                {
                    //前面
                    double sizeX = (Math.Abs(index[11] - index[4]) + 1) / index[9];
                    double sizeY = (Math.Abs(index[12] - index[5]) + 1) / index[10];
                    double sizeZ = secLayerOut;
                    fromX = index[4] + sizeX * (Width - index[7]);
                    fromY = index[5] - sizeY * (Height - index[8]);
                    fromZ = index[6];
                    toX = fromX + sizeX;
                    toY = fromY + sizeY;
                    toZ = fromZ + (1 - sizeZ);
                }
                else if (passStr == "ght")
                {
                    //uv
                    imageX = index[0] - (Width - index[7]) * 0.25;
                    imageY = index[1] + (Height - index[8]) * 0.25;
                    imageH = index[2] - (Width - index[7]) * 0.25;
                    imageW = index[3] + (Height - index[8]) * 0.25;
                    uv = "\"uv\": [" + imageX + "," + imageY + "," + imageH + "," + imageW + "],\"texture\": \"#skin\"";
                    //右侧
                    double sizeX = secLayerOut;
                    double sizeY = (Math.Abs(index[12] - index[5]) + 1) / index[10];
                    double sizeZ = (Math.Abs(index[13] - index[6]) + 1) / index[9];
                    fromX = index[4];
                    fromY = index[5] - sizeY * (Height - index[8]);
                    fromZ = index[6] + sizeZ * (Width - index[7]);//-
                    toX = fromX + (1 - sizeX);
                    toY = fromY + sizeY;
                    toZ = fromZ + sizeZ;
                }
                else if (passStr == "ack")
                {
                    //uv
                    imageX = index[0] - (Width - index[7]) * 0.25;
                    imageY = index[1] + (Height - index[8]) * 0.25;
                    imageH = index[2] - (Width - index[7]) * 0.25;
                    imageW = index[3] + (Height - index[8]) * 0.25;
                    uv = "\"uv\": [" + imageX + "," + imageY + "," + imageH + "," + imageW + "],\"texture\": \"#skin\"";
                    //背面
                    double sizeX = (Math.Abs(index[11] - index[4]) + 1) / index[9];
                    double sizeY = (Math.Abs(index[12] - index[5]) + 1) / index[10];
                    double sizeZ = secLayerOut;
                    fromX = index[4] + sizeX * (Width - index[7]);//-
                    fromY = index[5] - sizeY * (Height - index[8]);
                    fromZ = index[6] + (1 - sizeZ);
                    toX = fromX + sizeX;
                    toY = fromY + sizeY;
                    toZ = fromZ + sizeZ;
                }
                else if (passStr == "Top")
                {
                    //顶部
                    double sizeX = (Math.Abs(index[11] - index[4]) + 1) / index[9];
                    double sizeY = secLayerOut;
                    double sizeZ = (Math.Abs(index[13] - index[6]) + 1) / index[10];
                    fromX = index[4] + sizeX * (Width - index[7]);
                    fromY = index[5];
                    fromZ = index[6] + sizeZ * (Height - index[8]);
                    toX = fromX + sizeX;
                    toY = fromY + (1 - sizeY);
                    toZ = fromZ + sizeZ;
                }
                else if (passStr == "tom")
                {
                    //底部
                    double sizeX = (Math.Abs(index[11] - index[4]) + 1) / index[10];
                    double sizeY = secLayerOut;
                    double sizeZ = (Math.Abs(index[13] - index[6]) + 1) / index[9];
                    fromX = index[4] + sizeX * (Height - index[8]);//-
                    //fromY = index[5] + (1 - sizeY);
                    fromY = index[5];
                    fromZ = index[6] + sizeZ * (Width - index[7]);
                    toX = fromX + sizeX;
                    toY = fromY + (1 - sizeY);
                    toZ = fromZ + sizeZ;
                }
            }
            string temp = "{\"__comment\":\"" + whichFace + "|" + Width + "|" + Height + "\",\"from\":[" + fromX + "," + fromY + "," + fromZ + "]," + "\"to\":[" + toX + "," + toY + "," + toZ + "],\"faces\":{\"up\":{" + uv + "},\"down\":{" + uv + "},\"west\":{" + uv + "},\"east\":{" + uv + "},\"north\":{" + uv + "},\"south\":{" + uv + "}}}";
            JObject allText = (JObject)JsonConvert.DeserializeObject(temp);
            return allText;
        }

        private ArrayList returnAFaceFromSkin(Bitmap skin, string __comment, bool whichMode)
        {
            double[] index = backIndex(__comment, whichMode);
            int skinX = (int)index[7];
            int skinY = (int)index[8];
            int skinWeight = (int)index[9];
            int skinHeight = (int)index[10];
            ArrayList arr = new ArrayList();
            if (whichMode)
            {
                //普通2格高
                outb("生成元素预览：" + __comment + "\r\n");
                for (int y = skinY; y < skinY + skinHeight; y++)
                {
                    for (int x = skinX; x < skinX + skinWeight; x++)
                    {
                        if (GetPixelColor(skin, x, y) != 0)
                        {
                            arr.Add(getAFace(__comment, x, y, whichMode));
                            outputBox.Text += "■";
                        }
                        else
                        {
                            outputBox.Text += "□";
                        }
                    }
                    outputBox.Text += "\r\n";
                }
            }
            else
            {
                //大头娃娃1格高
                string passStr = __comment.Substring(__comment.Length - 3, 3);
                if (passStr == "ght" || passStr == "tom")
                {
                    for (int y = skinY; y < skinY + skinHeight; y++)
                    {
                        for (int x = skinX + skinWeight; x > skinX; x--)
                        {
                            if (GetPixelColor(skin, x, y) != 0)
                            {
                                arr.Add(getAFace(__comment, x, y, whichMode));
                            }
                        }
                    }
                }
                else
                {
                    for (int y = skinY; y < skinY + skinHeight; y++)
                    {
                        for (int x = skinX; x < skinX + skinWeight; x++)
                        {
                            if (GetPixelColor(skin, x, y) != 0)
                            {
                                arr.Add(getAFace(__comment, x, y, whichMode));
                            }
                        }
                    }
                }
            }
            return arr;
        }

        //private JObject returnAPixel2JObj(string __comment, float fromX, float fromY, float fromZ, float faceX, float faceY, string skinNameDefaultIs_skin) 
        //{
        //    float toX = fromX + 1;
        //    float toY = fromY + 1;
        //    float toZ = fromZ + 1;
        //    float faceHeight = faceX + 1;
        //    float faceWeight = faceY + 1;
        //    string uv = "\"uv\": [" + faceX + "," + faceY + "," + faceHeight + "," + faceWeight + "],\"texture\": \"" + skinNameDefaultIs_skin + "\"";
        //    string temp = "{\"__comment\":\"" + __comment + "\",\"from\":[" + fromX + "," + fromY + "," + fromZ + "]," + "\"to\":[" + toX + "," + toY + "," + toZ + "],\"faces\":{\"up\":{" + uv + "},\"down\":{" + uv + "},\"west\":{" + uv + "},\"east\":{" + uv + "},\"north\":{" + uv + "},\"south\":{" + uv + "}}}";
        //    JObject allText = (JObject)JsonConvert.DeserializeObject(temp);
        //    return allText;
        //}

        private void outb(string text2out)
        {
            outputBox.Text += "\r\n[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + text2out;
        }

        //会丢失透明度，弃用
        //private Bitmap CutImage(Bitmap pic, Rectangle rect)
        //{
        //    Image img = Image.FromHbitmap(pic.GetHbitmap());
        //    Bitmap b = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
        //    Graphics g = Graphics.FromImage(b);
        //    g.DrawImage(img, 0, 0, rect, GraphicsUnit.Pixel);
        //    g.Dispose();
        //    return b;
        //}

        private int GetPixelColor(Bitmap pic, int width, int height) 
        {
            int testColor = pic.GetPixel(width, height).ToArgb();
            return testColor;
        }

        int aboutClicked = 0;

        private void osAbout_Click(object sender, EventArgs e)
        {
            aboutClicked++;
            MessageBox.Show("感谢您的使用！如需联系请优先使用MCBBS或QQ\r\n具体联系方式请贴内留言或查看MCH（上一个项目）的关于部分。", "命中：" + aboutClicked);
            if (aboutClicked == 2)
            {
                MessageBox.Show("诶呀不要戳了_(:3」∠)_");
            }
            if (aboutClicked == 20)
            {
                MessageBox.Show("为什么不听劝_(:3」∠)_");
            }
            if (aboutClicked == 50)
            {
                MessageBox.Show("            _(:3」∠)_");
            }
            if (aboutClicked == 100)
            {
                MessageBox.Show(" ", "哦。");
            }
        }

        //格式化json字符串
        //private string ConvertJsonString(string str)
        //{
        //    JsonSerializer serializer = new JsonSerializer();
        //    TextReader tr = new StringReader(str);
        //    JsonTextReader jtr = new JsonTextReader(tr);
        //    object obj = serializer.Deserialize(jtr);
        //    if (obj != null)
        //    {
        //        StringWriter textWriter = new StringWriter();
        //        JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
        //        {
        //            Formatting = Formatting.Indented,
        //            Indentation = 4,
        //            IndentChar = ' '
        //        };
        //        serializer.Serialize(jsonWriter, obj);
        //        return textWriter.ToString();
        //    }
        //    else
        //    {
        //        return str;
        //    }          
        //}
    }
}
