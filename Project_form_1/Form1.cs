using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Library;

namespace Project_form_1
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            
        }
        // экземпляр класс Patient, в него ведется запись данных о пользователе
        Patient man = new Patient();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void поле_Имя_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (поле_Имя.Text != "" && поле_Фамилия.Text != "" && поле_Отчество.Text != "" && поле_номер.Text != "" && поле_почта.Text != "")
                if (checkBox1.Checked == true)
                {
                    // запись данных о пользователе
                    man.Name = поле_Имя.Text;
                    man.Surname = поле_Фамилия.Text;
                    if (поле_Отчество.Text != "-")
                        man.Patronymic = поле_Отчество.Text;
                    man.Phone = поле_номер.Text;
                    man.Mail = поле_почта.Text;

                    man.BDay = dateTimePicker1.Value.ToString("dd");
                    man.BMonth = dateTimePicker1.Value.ToString("MM");
                    man.BYear = dateTimePicker1.Value.ToString("yyyy");

                    // определение пола пользователя
                    if (radioButton1.Checked)
                        man.Gender = radioButton1.Text;
                    else
                        man.Gender = radioButton2.Text;
                    
                    if (radioButton2.Checked)
                        man.Gender = radioButton2.Text;
                    else
                        man.Gender = radioButton1.Text;

                    // вывод записанной информации
                    MessageBox.Show("Данные успешно записаны");
                    MessageBox.Show(man.Print_inf());

                    // связь формы "Окно регистрации" с формой "Пароль и полис ОМС"
                    // передача информации о пользователе в форму "Пароль и полис ОМС" 
                    Form2 newForm = new Form2(man);
                    newForm.Show();
                }
                else
                {
                    // вывод сообщения при ненажатии галочки в поле согласия на обработку перс. данных
                    MessageBox.Show("Ваши данные не будут использованы для передачи третьим лицам. С правилами обработки и хранения персональных данных пользователей вы можете ознакомиться на сайте");
                }
            else
            {
                // обработка незаполнения какого-либо поля перс. данных
                if (поле_Имя.Text == "")
                    MessageBox.Show("Заполните, пожалуйста, имя");
                if (поле_Фамилия.Text == "")
                    MessageBox.Show("Заполните, пожалуйста, фамилию");
                if (поле_Отчество.Text == "")
                    MessageBox.Show("Заполните, пожалуйста, отчество. При его отсутствии поставьте -");
                if (поле_номер.Text == "")
                    MessageBox.Show("Заполните, пожалуйста, номер телефона");
                if (поле_почта.Text == "")
                    MessageBox.Show("Заполните, пожалуйста, адрес электронной почты");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ссылка на сайт с ответами на вопросы, которые могут возникнуть у пользователя
            System.Diagnostics.Process.Start("https://medinfo-yar.ru/index.php/help#how");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}