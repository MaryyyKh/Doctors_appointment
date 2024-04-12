/*
using System;

namespace Library_1
{

        -------------------------
        abstract class Hospital
        {
            private int adress;
            public int Adress { get; set; }
            abstract public void Print_inf();
        }
        -------------------------

        class Person
        {
            private string name_, surname_, med_policy_;
            private int year_of_birth_, t_;
            private int pin_code_ = 39571;
            public string Name
            {
                set { name_ = value; }
                get { return name_; }
            }

            public string Surname
            {
                set { surname_ = value; }
                get { return surname_; }
            }

            public string MedPolicy
            {
                set { med_policy_ = value; }
                get { return med_policy_; }
            }

            public int YearOfBirth
            {
                set { year_of_birth_ = value; }
                get { return year_of_birth_; }
            }

            public int T
            {
                set { t_ = value; }
                get { return t_; }
            }

            public int PinCode
            {
                set { pin_code_ = value; }
                get { return pin_code_; }
            }
            public Person() { }
            public Person(string name, string surname)
            {
                name_ = name;
                surname_ = surname;
                year_of_birth_ = 2000;
                med_policy_ = "0000000000000000";
                t_ = 1;
            }
            public Person(string name, string surname, string t, int year_of_birth, string med_policy)
            {
                name_ = name;
                surname_ = surname;
                year_of_birth_ = year_of_birth;

                t_ = (t == "Ж") ? 1 : 0;

                if (year_of_birth_ > 2023)
                    year_of_birth_ = -1;

                med_policy_ = med_policy;
            }
            public void Print_inf()
            {
                Console.WriteLine("Ваши данные для входа: " + Name + " " + Surname + "\n\n" + "Номер полиса ОМС: " + med_policy_);
            }

            public string Print_inf_2()
            {
                return "Ваши данные: " + Name + " " + Surname + " " + YearOfBirth + " г.р. пол " + T;
            }
        public void Print_new_inf(string name, string surname)
            {
                Console.WriteLine("Регистрация пройдена. Авторизация: " + name + " " + surname + "\n\n" + "Номер полиса ОМС: " + med_policy_);
            }
            public void Check_Pin_Code(ref int pin_to_check, out int result_)
            {
                result_ = pin_to_check == pin_code_ ? 1 : 0;
            }

        }

        class MedicalWorker : Person
        {
            private int work_experience_;
            private string phone_number_, mail_;
            private string patient_;
            private int p_base_number_;
            private string[] base_ = new string[100];

            public int WorkExperience
            {
                set { work_experience_ = value; }
                get { return work_experience_; }
            }

            public string PhoneNumber
            {
                set { phone_number_ = value; }
                get { return phone_number_; }
            }

            public string Mail
            {
                set
                {
                    if (value.Substring(value.Length - 9) != "@med.info")
                        Console.WriteLine("Почта указана неверно. В качестве логина используйте свою рабочую почту(домен @med.info)");
                    else
                        mail_ = value;
                }
                get { return mail_; }
            }

            public string[] Base_
            {
                set { base_ = value; }
                get { return base_; }
            }
            public MedicalWorker() { }
            public MedicalWorker(string name, string surname)
            {
                Name = name;
                Surname = surname;
                phone_number_ = "+79999999999";
                Mail = "aaaa@med.info";
                WorkExperience = 10;
            }
            new public void Print_inf()
            {
                Console.WriteLine("Сведения о сотруднике " + Name + " " + Surname + ":");
                Console.WriteLine("Почта: " + mail_ + "\n" + "Номер телефона: " + phone_number_ + "\n" + "Стаж работы: " + work_experience_ + " лет");
            }

            public virtual void Print_new_inf(string name, string surname, int work_experience)
            {
                Console.WriteLine("Сведения о сотруднике " + name + " " + surname + ":");
                Console.WriteLine("Стаж работы: " + work_experience + " лет");
            }
            public void Print_new_inf(string name, string surname, string mail, string phone_number)
            {
                Console.WriteLine("Сведения о сотруднике " + name + " " + surname + ":");
                Console.WriteLine("Почта: " + mail + "\n" + "Номер телефона: " + phone_number);
            }

            public void Check()
            {

            }
            public int Take_inf(string patient)
            {
                int i = 0;
                while (base_[i] != null)
                    i++;
                p_base_number_ = i + 1;
                base_[p_base_number_ - 1] = patient_;
                return p_base_number_;
            }
        }

        class Nurse : MedicalWorker
        {
            private int cnt_patient_;
            private string med_education_;
            private string[] base_illnesses_ = new string[100];

            public int CntPatient
            {
                set { cnt_patient_ = value; }
                get { return cnt_patient_; }
            }

            public string MedEducation
            {
                set { med_education_ = value; }
                get { return med_education_; }
            }

            new public void Print_inf()
            {
                Console.WriteLine("Сведения о медсестре " + Name + " " + Surname + "(количество пациентов - " + CntPatient + "):");
                Console.WriteLine("Почта: " + Mail + "\n" + "Номер телефона: " + Mail + "\n" + "Стаж работы: " + WorkExperience + " лет" + "\n" + "Образование: " + MedEducation);
            }
            public override void Print_new_inf(string name, string surname, int work_experience)
            {
                Console.WriteLine("Сведения о сотруднике " + name + " " + surname + ":");
                Console.WriteLine("Стаж работы: " + work_experience + " лет");
            }
            public string Take_inf(string illness, int patient_number)
            {
                base_illnesses_[patient_number - 1] += illness;
                return "Данные успешно записаны.";
            }
        }

        class Appointment
        {
            private int day_, month_, year_;
            private string time_, doctor_;
            public int Day
            {
                set { day_ = value; }
                get { return day_; }
            }
            public int Month
            {
                set { month_ = value; }
                get { return month_; }
            }
            public int Year
            {
                set { year_ = value; }
                get { return year_; }
            }
            public string Time
            {
                set { time_ = value; }
                get { return time_; }
            }
            public string Doctor
            {
                set { doctor_ = value; }
                get { return doctor_; }
            }
            public Appointment() { }
            public Appointment(string time, string doctor)
            {
                time_ = time;
                doctor_ = doctor;

                string date = DateTime.Now.ToString();
                string[] dt = date.Split('.');
                ------------------------------------
                for (int i = 0; i < dt.Length; ++i)
                    Console.Write(dt[i] + "\n");
                --------------------------------
                Day = Convert.ToInt32(dt[0]);
                Month = Convert.ToInt32(dt[1]);
                Year = Convert.ToInt32(dt[2].Split(' ')[0]);
            }
            public static bool operator <(Appointment a1, Appointment a2)
            {
                return a1.Day < a2.Day;
            }
            public static bool operator >(Appointment a1, Appointment a2)
            {
                return a1.Day > a2.Day;
            }
            public static Appointment operator ++(Appointment n)
            {
                return new Appointment { Day = n.Day++ };
            }
            public void Print()
            {
                Console.WriteLine("Дата записи: " + Day + "." + Month + "." + Year);
            }
        }
}
*/