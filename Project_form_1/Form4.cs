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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // экземпляр класс Patient, в него ведется запись данных о пользователе
        Patient man = new Patient();

        // экземпляр класс Patient,
        // необходим для примера работы уведомлений о появлении нового окна для записи
        Patient man2 = new Patient("Елена", "Александрова", "Дмитриевна", "elena83@gmail.com", "+79401234476", "женский");

        // экземпляр класс Doctor, доктора, к которым может записаться пользователь
        Doctor doc1 = new Doctor("Елена", "Баунова", "Алексеевна", 40, "baunova.e.a@med.info");
        Doctor doc2 = new Doctor("Юлия", "Горбачевская", "Александровна", 7, "gorbachevskaya.y.a@med.info");
        Doctor doc3 = new Doctor("Ирина", "Иванова", "Владимировна", 36, "ivanova.i.v@med.info");
        Doctor doc4 = new Doctor("Михаил", "Коновалов", "Алексеевич", 5, "konovalov.m.a@med.info");

        // экземпляр класс Appjintment,
        // в него ведется запись данных о дате, времени и специалисте, выбранных пользователем
        Appointment app = new Appointment();

        // логическая переменная, показывающая, появлялось ли уведомление о новом окне для записи
        bool f = false;

        // конструктор класса Form4("Запись ко врачу"),
        // принимающий данные о пользователе из Form3("Вход в приложение")
        public Form4(Patient man_)
        {
            InitializeComponent();
            man = man_;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();

            // инициализация времени приема для докторов
            doc1.ReceptionTime = "12:00-16:00";
            doc2.ReceptionTime = "09:00-11:00";
            doc3.ReceptionTime = "12:00-16:00";
            doc4.ReceptionTime = "16:00-20:00";

            // отображение доступного времени записи в зависимости от выбранного доктора
            if (selectedState == "Баунова Е. А.") 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = true;
                button12.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button6.Enabled = false;
                button11.Enabled = false;
                button10.Enabled = false;
                button13.Enabled = false;

                // Определение доктора, к которому планирует записаться пользователь
                app.Doc = doc1.NameOfPerson;

                
            }
            else if (selectedState == "Горбачевская Ю. А.") 
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button7.Enabled = false;
                button12.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button6.Enabled = false;
                button11.Enabled = false;
                button10.Enabled = false;
                button13.Enabled = false;

                // Определение доктора, к которому планирует записаться пользователь
                app.Doc = doc2.NameOfPerson;
            }
            else if (selectedState == "Иванова И. В.")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = true;
                button12.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button6.Enabled = false;
                button11.Enabled = false;
                button10.Enabled = false;
                button13.Enabled = false;

                // Определение доктора, к которому планирует записаться пользователь
                app.Doc = doc3.NameOfPerson;

            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Enabled = false;
                button12.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button6.Enabled = true;
                button11.Enabled = true;
                button10.Enabled = true;
                button13.Enabled = true;

                // Определение доктора, к которому планирует записаться пользователь
                app.Doc = doc4.NameOfPerson;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // вывод информации о докторе, которого выбрал пользователь
            // при нажатии соответствующей кнопки ("Информация о специалисте")
            if (comboBox1.Text == "Баунова Е. А.")
            {
                MessageBox.Show(doc1.PrintInformation());
            }
            else if (comboBox1.Text == "Горбачевская Ю. А.")
            {
                MessageBox.Show(doc2.PrintInformation());
            }
            else if (comboBox1.Text == "Иванова И. В.")
            {
                MessageBox.Show(doc3.PrintInformation());
            }
            else
            {
                MessageBox.Show(doc4.PrintInformation());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // экземпляр класс Appointment,
            // необходим для примера работы уведомлений о появлении нового окна для записи
            Appointment app2 = new Appointment(man2, "12.06.2023", "14:00", doc3);

            app.NameOfPerson = man.NameOfPerson;
            if (dateTimePicker1.Value.Year < DateTime.Now.Year ||
                dateTimePicker1.Value.Month < DateTime.Now.Month ||
                dateTimePicker1.Value.Day < DateTime.Now.Day)
                MessageBox.Show("Невозможно выбрать дату раньше, чем текущая. " +
                    "Пожалуйста, выберите другую дату.");
            else
            {
                app.Day = dateTimePicker1.Value.ToString("dd");
                app.Month = dateTimePicker1.Value.ToString("MM");
                app.Year = dateTimePicker1.Value.ToString("yyyy");
            }
            MessageBox.Show(app.PrintInformation());


            if (app.Doc.PrintInit() == "И. В. Иванова") 
            {
                // Появление нового окна для записиуведомление об этом пользователя
                button8.ForeColor = button1.ForeColor;

                // конструкция, необходимая для того,
                // чтобы уведомление появилось только 1 раз
                if (!f)
                {
                    // уведомление пользователя о появлении нового окна для записи
                    DialogResult result = MessageBox.Show("Появилось новое окно для записи к врачу:" + "\n" + "12.06.2023 14:00" + "\n" +
                                                           "Записаться?", "Уведомление",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                                                           MessageBoxDefaultButton.Button1);
                    
                    // Пользователь может либо записаться на освободившееся время и дату,
                    // либо не делать этого
                    if (result == DialogResult.Yes)
                    {
                        app.Day = app2.Day;
                        app.Month = app2.Month;
                        app.Year = app2.Year;
                        app.Time = app2.Time;

                        MessageBox.Show(app.PrintInformation());
                    }

                    f = true;
                }
            }
        }

        // 08:00
        private void button1_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button1.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button1.Text;
        }

        // 18:00
        private void button10_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button10.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button10.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // отметка о том, что записаться на прием
            // в 14:00 12.06.2023 к Ивановой И. В. невозможно
            if (app.Doc.PrintInit() == "И. В. Иванова" && dateTimePicker1.Value.Day == 12 && dateTimePicker1.Value.Month == 6 && dateTimePicker1.Value.Year == 2023)
            {
                button8.ForeColor = Color.IndianRed;
            }

            if (dateTimePicker1.Value.Year < DateTime.Now.Year ||
                dateTimePicker1.Value.Month < DateTime.Now.Month ||
                dateTimePicker1.Value.Day < DateTime.Now.Day)
                MessageBox.Show("Невозможно выбрать дату раньше, чем текущая. " +
                    "Пожалуйста, выберите другую дату.");
        }

        // 09:00
        private void button2_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button2.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button2.Text;
        }

        // 10:00
        private void button4_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button4.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button4.Text;
        }

        // 11:00
        private void button5_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button5.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button5.Text;
        }

        // 12:00
        private void button7_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button7.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button7.Text;
        }

        // 13:00
        private void button12_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button12.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button12.Text;
        }

        // 14:00
        private void button8_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button8.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button8.Text;
        }

        // 15:00
        private void button9_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button9.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button9.Text;
        }

        // 16:00
        private void button6_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button6.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button6.Text;
        }

        // 17:00
        private void button11_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button11.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button11.Text;
        }

        // 19:00
        private void button13_Click(object sender, EventArgs e)
        {
            // проверка, не пытается ли пользователь записаться на уже занятое время и дату
            // если да, показывается сообщение о невозможности это сделать,
            // иначе заполняются данные ячейки Time элемента app
            if (button13.ForeColor == Color.IndianRed)
                MessageBox.Show("К сожалению, данное время уже занято. Пожалуйста, выберите другое время");
            else
                app.Time = button13.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }
    }
}