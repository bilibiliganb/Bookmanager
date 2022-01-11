using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login1 : Form
    {
        public login1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!="")
            {
                login(); 
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }
        //登录方法，验证是否允许登录，允许返回真
        public void login()
        {
            //用户
            if(radioButtonUser.Checked==true)
            {
                Dao dao = new Dao();
                string sql = "select * from t_user where id='"+textBox1.Text+"'and psw='"+ textBox2.Text+"'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();
                    Data.depno = dc["depno"].ToString();
                    Data.depname = dc["depname"].ToString();
                    Data.grade = dc["grade"].ToString();
                    Data.sex = dc["sex"].ToString();
                    Data.tell = dc["tell"].ToString();
                    Data.addr = dc["addr"].ToString();
                    Data.Class = dc["class"].ToString();
                    MessageBox.Show("登录成功");
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.Daoclose();
            }
     
            //管理员
            if(radioButtonAdmin.Checked==true)
            {
                Dao dao = new Dao();
                string sql = "select * from t_admin where id='" + textBox1.Text + "'and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 a = new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.Daoclose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
