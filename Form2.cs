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
        string liningTypeValue, reservedDeformation, initialSupportid, strengthenSupportId, secondaryLiningId, scopeOfApplication;
        string staw, stia, aap, aal, aarls, sm, sf, aw, ia, floor;

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
                        "lining_type_value, reserved_deformation, initial_support_id, strengthen_support_id, secondary_lining_id, scope_of_application from ";
                        
            if (singleDoubleLine.SelectedValue.ToString() != null && singleDoubleLine.SelectedValue.ToString() != "")
            {
                if (singleDoubleLine.SelectedValue.ToString() == "1") {
                    sql += "drilling_blasting_double_line where 1 = 1";
                } else
                {
                    sql += "drilling_blasting_ingle_line where 1 = 1";
                }
            
            } else
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

            }
            
            string sql2 = "select shotcrete_thickness_arch_wall, shotcrete_thickness_inverted_arch, anchor_arm_position, anchor_arm_length, anchor_arm_ring_longitudinal_spacing, steel_mesh from drilling_blasting_initial_support where id = '" + initialSupportid + "'";
            dr = dao.read(sql2);
            while (dr.Read())
            {
                staw = dr[0].ToString();
                stia = dr[1].ToString();
                aap = dr[2].ToString();
                aal = dr[3].ToString();
                aarls = dr[4].ToString();
                sm = dr[5].ToString();

            }

            string sql3 = "select steel_frame from strengthen_support where id = '" + strengthenSupportId + "'";
            dr = dao.read(sql3);
            while (dr.Read())
            {
                sf = dr[0].ToString();

            }

            string sql4 = "select arch_wall, inverted_arch, floor from thickness_of_secondary_lining where id = '" + secondaryLiningId + "'";
            dr = dao.read(sql3);
            while (dr.Read())
            {
                aw = dr[0].ToString();
                ia = dr[1].ToString();
                floor = dr[2].ToString();
            }
            /**
            string sql4 = "select arch_wall, inverted_arch, floor from thickness_of_secondary_lining where id = '" + secondaryLiningId + "'";
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
            try
            {

                e.Graphics.DrawString("衬砌类型：", fntTxt, brush, new System.Drawing.Point(15, 10));
                e.Graphics.DrawString(liningTypeValue, fntTxt, brush, new System.Drawing.Point(80, 10));
                e.Graphics.DrawString("预留变形量：", fntTxt, brush, new System.Drawing.Point(15, 30));
                e.Graphics.DrawString(reservedDeformation, fntTxt, brush, new System.Drawing.Point(80, 30));
                e.Graphics.DrawString("断面形式：", fntTxt, brush, new System.Drawing.Point(15, 50));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 50));
                e.Graphics.DrawString("喷栓：", fntTxt, brush, new System.Drawing.Point(15, 70));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 70));
                e.Graphics.DrawString("钢架形式：", fntTxt, brush, new System.Drawing.Point(15, 90));
                e.Graphics.DrawString(sf, fntTxt, brush, new System.Drawing.Point(80, 90));
                e.Graphics.DrawString("钢架锁脚：", fntTxt, brush, new System.Drawing.Point(15, 110));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 110));
                e.Graphics.DrawString("锚杆形式：", fntTxt, brush, new System.Drawing.Point(15, 130));
                e.Graphics.DrawString(aap + "、" + aal, fntTxt, brush, new System.Drawing.Point(80, 130));
                e.Graphics.DrawString("钢筋网：", fntTxt, brush, new System.Drawing.Point(15, 150));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 150));
                e.Graphics.DrawString("二次衬砌：", fntTxt, brush, new System.Drawing.Point(15, 170));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 170));
                e.Graphics.DrawString("超前支护措施：", fntTxt, brush, new System.Drawing.Point(15, 190));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 190));
                e.Graphics.DrawString("施工工法：", fntTxt, brush, new System.Drawing.Point(15, 210));
                e.Graphics.DrawString(initialSupportid, fntTxt, brush, new System.Drawing.Point(80, 210));

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
