using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        string liningTypeValue, reservedDeformation, initialSupportid, strengthenSupportId, secondaryLiningId, scopeOfApplication, liningTypeCode, anchorArm, remark;
        string shotcreteThicknessArchWall, shotcreteThicknessInvertedArch, anchorArmPosition, anchorArmLength, aarls, steelFrame, archWall, invertedArch, floor, constructionMethod, advanceSupportMeasures, workingFaceReinforce;
        string sectionForm, shotcrete, steelFrameForm, steelFrameLockFoot, anchorArmForm, steelMesh, secondaryLining, bufferEnergyAbsorbingLayer, groutingReinforcement;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string rbShotcrete, rbSteelMesh, rbAnchorArm, rbSteelFrame, caveEntranceTypeValue1, caveEntranceTypeValue2, designRequirement, liningSupports;

        private void button2_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.Document != null)
            {
                printDialog1.Document = printDocument1;
                DialogResult dr = printDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }

            MessageBox.Show("页面为空");
        }

        string fortificationLength1, fortificationLength2, structuralRequirements, supportingMeasures, keepWarmDrainage;

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void choseImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK && (openFileDialog1.FileName != ""))
            {
                pictureBox2.ImageLocation = openfile.FileName;
                //textbox.Text = openfile.FileName;
            }

            openfile.Dispose();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "select " +
                        "lining_type_value, reserved_deformation, initial_support_id, strengthen_support_id, secondary_lining_id, scope_of_application, lining_type_code from ";

            if (singleDoubleLine.SelectedValue.ToString() != null && singleDoubleLine.SelectedValue.ToString() != "")
            {
                if (singleDoubleLine.SelectedValue.ToString() == "1")
                {
                    sql += "drilling_blasting_double_line where 1 = 1";
                }
                else
                {
                    sql += "drilling_blasting_ingle_line where 1 = 1";
                }

            }
            else
            {
                MessageBox.Show("所选条件不足！");
                return;
            }
            if (surroundingRockLevel.SelectedValue.ToString() != null && surroundingRockLevel.SelectedValue.ToString() != "")
            {

                sql += " and surrounding_rock_level_code = '" + surroundingRockLevel.SelectedValue.ToString() + "'";
            }
            if (buried.SelectedValue.ToString() != null && buried.SelectedValue.ToString() != "")
            {

                sql += " and buried_code = '" + buried.SelectedValue.ToString() + "'";
            }
            if (rockHardness.SelectedValue.ToString() != null && rockHardness.SelectedValue.ToString() != "")
            {

                sql += " and rock_hardness_code = '" + rockHardness.SelectedValue.ToString() + "'";
            }
            if (bedding.SelectedValue.ToString() != null && bedding.SelectedValue.ToString() != "")
            {

                sql += " and bedding_code = '" + bedding.SelectedValue.ToString() + "'";
            }

            if (biasVoltage.SelectedValue.ToString() != null && biasVoltage.SelectedValue.ToString() != "")
            {

                sql += " and bias_voltage_code = '" + biasVoltage.SelectedValue.ToString() + "'";
            }
            if (antiseismic.SelectedValue.ToString() != null && antiseismic.SelectedValue.ToString() != "")
            {

                sql += " and antiseismic_code = '" + antiseismic.SelectedValue.ToString() + "'";
            }
            if (gentleDip.SelectedValue.ToString() != null && gentleDip.SelectedValue.ToString() != "")
            {

                sql += " and gentle_dip_code = '" + gentleDip.SelectedValue.ToString() + "'";
            }

            Dao dao = new Dao();
            OleDbDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                liningTypeValue = dr[0].ToString();
                reservedDeformation = dr[1].ToString();
                initialSupportid = dr[2].ToString();
                strengthenSupportId = dr[3].ToString();
                secondaryLiningId = dr[4].ToString();
                scopeOfApplication = dr[5].ToString();
                liningTypeCode = dr[6].ToString();

            }

            string sql2 = "select shotcrete_thickness_arch_wall, shotcrete_thickness_inverted_arch, anchor_arm_position, anchor_arm_length, anchor_arm_ring_longitudinal_spacing, steel_mesh from drilling_blasting_initial_support where id = '" + initialSupportid + "'";
            dr = dao.read(sql2);
            while (dr.Read())
            {
                shotcreteThicknessArchWall = dr[0].ToString();
                shotcreteThicknessInvertedArch = dr[1].ToString();
                anchorArmPosition = dr[2].ToString();
                anchorArmLength = dr[3].ToString();
                aarls = dr[4].ToString();
                steelMesh = dr[5].ToString();

            }

            string sql3 = "select steel_frame from strengthen_support where id = '" + strengthenSupportId + "'";
            dr = dao.read(sql3);
            while (dr.Read())
            {
                steelFrame = dr[0].ToString();

            }

            string sql4 = "select arch_wall, inverted_arch, floor from thickness_of_secondary_lining where id = '" + secondaryLiningId + "'";
            dr = dao.read(sql4);
            while (dr.Read())
            {
                archWall = dr[0].ToString();
                invertedArch = dr[1].ToString();
                floor = dr[2].ToString();
            }
            if (mechanizedSupporting.SelectedValue.ToString() != null && mechanizedSupporting.SelectedValue.ToString() != "")
            {
                string sql5 = " where single_double_line_code = '" + singleDoubleLine.SelectedValue.ToString() + "' and surrounding_rock_level_code = '" + surroundingRockLevel.SelectedValue.ToString() + "' and lining_type_code = '" + liningTypeCode + "'";
                if (mechanizedSupporting.SelectedValue.ToString() == "1")
                {
                    sql5 = "select construction_method, advance_support_measures from drilling_blasting_basic_mechanization" + sql5;
                    dr = dao.read(sql5);
                    while (dr.Read())
                    {
                        constructionMethod = dr[0].ToString();
                        advanceSupportMeasures = dr[1].ToString();

                    }
                }
                else
                {
                    sql5 = "select construction_method, advance_support_measures, working_face_reinforce, remark from drilling_blasting_large_mechanization" + sql5;
                    dr = dao.read(sql5);
                    while (dr.Read())
                    {
                        constructionMethod = dr[0].ToString();
                        advanceSupportMeasures = dr[1].ToString();
                        workingFaceReinforce = dr[2].ToString();
                        remark = dr[3].ToString();
                    }
                }

            }
            if (largeDeformation.SelectedValue.ToString() != null && largeDeformation.SelectedValue.ToString() != "")
            {
                string sql6;
                if (singleDoubleLine.SelectedValue.ToString() == "1")
                {
                    sql6 = "select lining_type_value, reserved_deformation, section_form, shotcrete, steel_frame_form, steel_frame_lock_foot, anchor_arm_form, steel_mesh, secondary_lining, buffer_energy_absorbing_layer from ingle_line_large_deformation_support_param"
                    + " where large_deformation_level_code = '" + largeDeformation.SelectedValue.ToString() + "' ";
                    dr = dao.read(sql6);
                    while (dr.Read())
                    {
                        liningTypeValue = dr[0].ToString();
                        reservedDeformation = dr[1].ToString();
                        sectionForm = dr[2].ToString();
                        shotcrete = dr[3].ToString();
                        steelFrameForm = dr[4].ToString();
                        steelFrameLockFoot = dr[5].ToString();
                        anchorArmForm = dr[6].ToString();
                        steelMesh = dr[7].ToString();
                        secondaryLining = dr[8].ToString();
                        bufferEnergyAbsorbingLayer = dr[9].ToString();

                    }
                }
                else
                {
                    sql6 = "select lining_type_value, reserved_deformation, section_form, shotcrete, steel_frame_form, steel_frame_lock_foot, anchor_arm_form, steel_mesh, secondary_lining, grouting_reinforcement, buffer_energy_absorbing_layer from double_line_large_deformation_support_param"
                    + " where large_deformation_level_code = '" + largeDeformation.SelectedValue.ToString() + "' ";
                    dr = dao.read(sql6);
                    while (dr.Read())
                    {
                        liningTypeValue = dr[0].ToString();
                        reservedDeformation = dr[1].ToString();
                        sectionForm = dr[2].ToString();
                        shotcrete = dr[3].ToString();
                        steelFrameForm = dr[4].ToString();
                        steelFrameLockFoot = dr[5].ToString();
                        anchorArmForm = dr[6].ToString();
                        steelMesh = dr[7].ToString();
                        secondaryLining = dr[8].ToString();
                        groutingReinforcement = dr[9].ToString();
                        bufferEnergyAbsorbingLayer = dr[10].ToString();

                    }
                }

            }
            if (rockburst.SelectedValue.ToString() != null && rockburst.SelectedValue.ToString() != "")
            {
                string sql7 = "select shotcrete, steel_mesh, anchor_arm, steel_frame from ";
                if (singleDoubleLine.SelectedValue.ToString() == "1")
                {
                    sql7 += "ingle_line_drilling_blasting_rockburst_support_param where rockburst_level_code = '" + rockburst.SelectedValue.ToString() + "' and surrounding_rock_level_code = '" + surroundingRockLevel.SelectedValue.ToString() + "'";
                }
                else
                {
                    sql7 += "double_line_drilling_blasting_rockburst_support_param where rockburst_level_code = '" + rockburst.SelectedValue.ToString() + "' and surrounding_rock_level_code = '" + surroundingRockLevel.SelectedValue.ToString() + "'";
                }
                dr = dao.read(sql7);
                while (dr.Read())
                {
                    rbShotcrete = dr[0].ToString();
                    rbSteelMesh = dr[1].ToString();
                    rbAnchorArm = dr[2].ToString();
                    rbSteelFrame = dr[3].ToString();
                    

                }
            }
            if (averageTemperature.SelectedValue.ToString() != null && averageTemperature.SelectedValue.ToString() != "")
            {
                string sql8 = "select fortification_length, structural_requirements, supporting_measures, keep_warm_drainage, cave_entrance_type_value from frost_resistance_of_tunnel where average_temperature_code = " + averageTemperature.SelectedValue.ToString() + " and cave_entrance_type_code = '1'";
                dr = dao.read(sql8);
                while (dr.Read())
                {
                    fortificationLength1 = dr[0].ToString();
                    structuralRequirements = dr[1].ToString();
                    supportingMeasures = dr[2].ToString();
                    keepWarmDrainage = dr[3].ToString();
                    caveEntranceTypeValue1 = dr[4].ToString();

                }
                string sql81 = "select fortification_length, structural_requirements, supporting_measures, keep_warm_drainage, cave_entrance_type_value from frost_resistance_of_tunnel where average_temperature_code = " + averageTemperature.SelectedValue.ToString() + " and cave_entrance_type_code = '2'";
                dr = dao.read(sql81);
                while (dr.Read())
                {
                    fortificationLength2 = dr[0].ToString();
                    structuralRequirements = dr[1].ToString();
                    supportingMeasures = dr[2].ToString();
                    keepWarmDrainage = dr[3].ToString();
                    caveEntranceTypeValue2 = dr[4].ToString();

                }
            }
            if (gas.SelectedValue.ToString() != null && gas.SelectedValue.ToString() != "")
            {
                string sql9 = "select design_requirement from gas_treatment_scheme where id = '" + gas.SelectedValue.ToString() + "'";
                dr = dao.read(sql9);
                while (dr.Read())
                {
                    designRequirement = dr[0].ToString();

                }
            }
            if (highEothermal.SelectedValue.ToString() != null && highEothermal.SelectedValue.ToString() != "")
            {
                string sql10 = "select lining_supports from high_eothermal_programme where id = '" + highEothermal.SelectedValue.ToString() + "'";
                dr = dao.read(sql10);
                while (dr.Read())
                {
                    liningSupports = dr[0].ToString();

                }
            }
            /**
            string sql5 = "select arch_wall, inverted_arch, floor from thickness_of_secondary_lining where id = '" + secondaryLiningId + "'";
            dr = dao.read(sql3);
            while (dr.Read())
            {
                aw = dr[0].ToString();
                ia = dr[1].ToString();
                floor = dr[2].ToString();
            }**/

            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 210, 279);
            printPreviewControl1.Document = printDocument1;
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            DataRow dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "Ⅱ级围岩";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "Ⅲ级围岩";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "Ⅳ级围岩";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "5";
            dr[1] = "Ⅴ级围岩";
            dt.Rows.Add(dr);
            surroundingRockLevel.DataSource = dt;
            surroundingRockLevel.DisplayMember = "val";//val这个字段为显示的值
            surroundingRockLevel.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "深埋";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "浅埋";
            dt.Rows.Add(dr);
            buried.DataSource = dt;
            buried.DisplayMember = "val";//val这个字段为显示的值
            buried.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "硬岩";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "软岩";
            dt.Rows.Add(dr);
            rockHardness.DataSource = dt;
            rockHardness.DisplayMember = "val";//val这个字段为显示的值
            rockHardness.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "是";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "否";
            dt.Rows.Add(dr);
            bedding.DataSource = dt;
            bedding.DisplayMember = "val";//val这个字段为显示的值
            bedding.ValueMember = "id";//id这个字段为后台获取的值

            biasVoltage.DataSource = dt;
            biasVoltage.DisplayMember = "val";//val这个字段为显示的值
            biasVoltage.ValueMember = "id";//id这个字段为后台获取的值

            antiseismic.DataSource = dt;
            antiseismic.DisplayMember = "val";//val这个字段为显示的值
            antiseismic.ValueMember = "id";//id这个字段为后台获取的值

            gentleDip.DataSource = dt;
            gentleDip.DisplayMember = "val";//val这个字段为显示的值
            gentleDip.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "钻爆法基本机械化";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "钻爆法大型机械化";
            dt.Rows.Add(dr);
            mechanizedSupporting.DataSource = dt;
            mechanizedSupporting.DisplayMember = "val";//val这个字段为显示的值
            mechanizedSupporting.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "单线";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "0";
            dr[1] = "双线";
            dt.Rows.Add(dr);
            singleDoubleLine.DataSource = dt;
            singleDoubleLine.DisplayMember = "val";//val这个字段为显示的值
            singleDoubleLine.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = " 一级（轻微）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "二级（中等）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "三级（严重）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "四级（极严重）";
            dt.Rows.Add(dr);
            largeDeformation.DataSource = dt;
            largeDeformation.DisplayMember = "val";//val这个字段为显示的值
            largeDeformation.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = " Ⅰ级（轻微）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "Ⅱ级（中等）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "Ⅲ级（强烈）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "Ⅳ级（极强）";
            dt.Rows.Add(dr);
            rockburst.DataSource = dt;
            rockburst.DisplayMember = "val";//val这个字段为显示的值
            rockburst.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "-8℃~0℃";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "-10℃~8℃";
            dt.Rows.Add(dr);
            averageTemperature.DataSource = dt;
            averageTemperature.DisplayMember = "val";//val这个字段为显示的值
            averageTemperature.ValueMember = "id";//id这个字段为后台获取的值

            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "活动断裂、深大断裂、构造交叉带、褶皱密集带、节理密集带";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "高瓦斯或瓦斯突出区段距洞口大于2000m时";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "高瓦斯或瓦斯突出区段距洞口2000m及以下，且海拔大于3000m时";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "5";
            dr[1] = "高瓦斯工区和瓦斯突出工区";
            dt.Rows.Add(dr);
            gas.DataSource = dt;
            gas.DisplayMember = "val";//val这个字段为显示的值
            gas.ValueMember = "id";//id这个字段为后台获取的值
            
            dt = new DataTable();//创建一个数据集
            dt.Columns.Add("id", typeof(String));
            dt.Columns.Add("val", typeof(String));
            dr = dt.NewRow();
            dr[0] = null;
            dr[1] = null;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "28～37℃";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "37～50℃";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "50～60℃";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = ">60℃（岩温）";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "5";
            dr[1] = ">45℃（水温）";
            dt.Rows.Add(dr);
            highEothermal.DataSource = dt;
            highEothermal.DisplayMember = "val";//val这个字段为显示的值
            highEothermal.ValueMember = "id";//id这个字段为后台获取的值


        }

        private void tunnelName_TextChanged(object sender, EventArgs e)
        {

        }

        private void surroundingRockLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fntTxt = new Font("宋体", 5, System.Drawing.FontStyle.Regular);//正文文字                  
            System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Black);//画刷      
            int y = 5;
            try
            {
                if (liningTypeValue != null && liningTypeValue != "")
                {
                    e.Graphics.DrawString("衬砌类型：", fntTxt, brush, new System.Drawing.Point(15, y));
                    e.Graphics.DrawString(liningTypeValue, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (reservedDeformation != null && reservedDeformation != "")
                {
                    e.Graphics.DrawString("预留变形量：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(reservedDeformation, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (sectionForm != null && sectionForm != "")
                {
                    e.Graphics.DrawString("断面形式：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(sectionForm, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                
                if (shotcreteThicknessArchWall != null && shotcreteThicknessArchWall != "")
                {
                    if (shotcrete != null && shotcrete != "")
                    {
                        e.Graphics.DrawString("喷砼（cm）：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(shotcrete, fntTxt, brush, new System.Drawing.Point(80, y));
                    } else
                    {
                        e.Graphics.DrawString("喷砼（cm）：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(shotcreteThicknessArchWall + "  " + shotcreteThicknessInvertedArch, fntTxt, brush, new System.Drawing.Point(80, y));
                    }
                    
                }
                if (anchorArmPosition != null && anchorArmPosition != "")
                {
                    if (anchorArmForm != null && anchorArmForm != "")
                    {
                        e.Graphics.DrawString("锚杆形式：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(anchorArmForm, fntTxt, brush, new System.Drawing.Point(80, y));
                    } else
                    {
                        e.Graphics.DrawString("锚杆：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(anchorArmPosition + "  " + anchorArmLength + "  " + aarls, fntTxt, brush, new System.Drawing.Point(80, y));
                    }
                    
                }
                if (steelMesh != null && steelMesh != "")
                {
                    e.Graphics.DrawString("钢筋网（cm）：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(steelMesh, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (steelFrame != null && steelFrame != "")
                {
                    if (steelFrameForm != null && steelFrameForm != "")
                    {
                        e.Graphics.DrawString("钢架形式：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(steelFrameForm, fntTxt, brush, new System.Drawing.Point(80, y));
                        e.Graphics.DrawString("钢架锁脚：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(steelFrameLockFoot, fntTxt, brush, new System.Drawing.Point(80, y));
                    } else
                    {
                        e.Graphics.DrawString("钢架：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(steelFrame, fntTxt, brush, new System.Drawing.Point(80, y));
                    }

                    
                }
                if (archWall != null && archWall != "")
                {
                    if (secondaryLining != null && secondaryLining != "") 
                    {
                        e.Graphics.DrawString("二次衬砌：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(secondaryLining, fntTxt, brush, new System.Drawing.Point(80, y));
                    } else
                    {
                        e.Graphics.DrawString("二次衬砌厚度(cm)：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                        e.Graphics.DrawString(archWall + "  " + invertedArch + "  " + floor, fntTxt, brush, new System.Drawing.Point(80, y));
                    }
                    
                }
                if (bufferEnergyAbsorbingLayer != null && bufferEnergyAbsorbingLayer != "")
                {
                    e.Graphics.DrawString("缓冲吸能层：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(bufferEnergyAbsorbingLayer, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (groutingReinforcement != null && groutingReinforcement != "")
                {
                    e.Graphics.DrawString("注浆加固：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(groutingReinforcement, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (scopeOfApplication != null && scopeOfApplication != "")
                {
                    e.Graphics.DrawString("适用范围：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(scopeOfApplication, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (constructionMethod != null && constructionMethod != "")
                {
                    e.Graphics.DrawString("工法：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(constructionMethod, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (advanceSupportMeasures != null && advanceSupportMeasures != "")
                {
                    e.Graphics.DrawString("超前支护措施：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(advanceSupportMeasures, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (workingFaceReinforce != null && workingFaceReinforce != "")
                {
                    e.Graphics.DrawString("掌子面加固：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(workingFaceReinforce, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (remark != null && remark != "")
                {
                    e.Graphics.DrawString("备注：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(remark, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                
                if (rockburst.SelectedValue.ToString() != null && rockburst.SelectedValue.ToString() != "")
                {
                    e.Graphics.DrawString("岩爆处理：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                }
                if (rbShotcrete != null && rbShotcrete != "")
                {
                    e.Graphics.DrawString("喷砼（cm）：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(rbShotcrete, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (rbSteelMesh != null && rbSteelMesh != "")
                {
                    e.Graphics.DrawString("钢筋网：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(rbSteelMesh, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (rbAnchorArm != null && rbAnchorArm != "")
                {
                    e.Graphics.DrawString("锚杆：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(rbAnchorArm, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (rbSteelFrame != null && rbSteelFrame != "")
                {
                    e.Graphics.DrawString("钢架：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(rbSteelFrame, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (averageTemperature.SelectedValue.ToString() != null && averageTemperature.SelectedValue.ToString() != "")
                {
                    e.Graphics.DrawString("抗冻处理：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString("类型&长度：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(caveEntranceTypeValue1 + "  " + fortificationLength1, fntTxt, brush, new System.Drawing.Point(80, y));
                    e.Graphics.DrawString(caveEntranceTypeValue2 + "  " + fortificationLength2, fntTxt, brush, new System.Drawing.Point(80, y += 9));
                    e.Graphics.DrawString("结构要求：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(structuralRequirements, fntTxt, brush, new System.Drawing.Point(80, y));
                    e.Graphics.DrawString("辅助措施：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(supportingMeasures, fntTxt, brush, new System.Drawing.Point(80, y));
                    e.Graphics.DrawString("保温防排水：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(keepWarmDrainage, fntTxt, brush, new System.Drawing.Point(80, y));

                }
                if (designRequirement != null && designRequirement != "")
                {
                    e.Graphics.DrawString("瓦斯，设计要求：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(designRequirement, fntTxt, brush, new System.Drawing.Point(80, y));
                }
                if (liningSupports != null && liningSupports != "")
                {
                    e.Graphics.DrawString("高地热衬砌支护：", fntTxt, brush, new System.Drawing.Point(15, y += 9));
                    e.Graphics.DrawString(liningSupports, fntTxt, brush, new System.Drawing.Point(80, y));
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
