using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Pet_Training_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<register> registers;
        ObservableCollection<session> sessions = new ObservableCollection<session>();
        ObservableCollection<attendance> attendances = new ObservableCollection<attendance>();
        ObservableCollection<pet> pets = new ObservableCollection<pet>();


        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            registers = Mystorage.ReadFromXmlFile<ObservableCollection<register>>("registers.xml");
            sessions = Mystorage.ReadFromXmlFile<ObservableCollection<session>>("sessions.xml");
             attendances = Mystorage.ReadFromXmlFile<ObservableCollection<attendance>>("attendances.xml"); ;
            LBx_attendenceList.ItemsSource = attendances;
            //Cbo_class.ItemsSource = sessions;
            LBx_Owner.ItemsSource = registers;
            Genderfill();
            Breedfill();
            //Sessionfill();
            Daysfill();
            tclass();
            petsBinding();
            Statusfill();



        }
        public void petsBinding()
        {
            pets = Mystorage.ReadFromXmlFile<ObservableCollection<pet>>("pets.xml"); ;
            LBx_OwnerPets.ItemsSource = pets;
        }
        public void attendenceBinding()
        {
            attendances = Mystorage.ReadFromXmlFile<ObservableCollection<attendance>>("attendances.xml");
            LBx_attendance.ItemsSource = attendances;
        }
       
        private void tclass()
        {
            ObservableCollection<string> ocTclass = new ObservableCollection<string>();
            ocTclass.Add("Basic Training 8AM TO 10AM");
            ocTclass.Add("Obedience Training 9AM TO 11AM");
            ocTclass.Add("Hand Signals Training 10AM TO 12PM");
            ocTclass.Add("Verbal Command Training 12PM TO 2PM");
            ocTclass.Add("House Training 3PM TO 5PM");
            Cbo_tclass.ItemsSource = ocTclass;
            Cbo_class.ItemsSource = ocTclass;
            Cbo_filter.ItemsSource = ocTclass;
        }
        private void Genderfill()
        {
            ObservableCollection<string> ocGender = new ObservableCollection<string>();
            ocGender.Add("Male");
            ocGender.Add("Female");
            Cbo_gender1.ItemsSource = ocGender;

            Cbo_gender1.SelectedItem = "Male";
        }
        //public void assinCobofill()
        //{

        //    List<string> pet1 = new List<string>();
        //    List<string> pet2 = new List<string>();
        //    List<string> pet3 = new List<string>();
        //    List<string> pet4 = new List<string>();
        //    List<string> pet5 = new List<string>();

        //    foreach (var p1 in pets)
        //    {
        //        pet1.Add(p1.petname1);
        //    }
        //    foreach (var p2 in registers)
        //    {
        //        pet1.Add(p2.petname2);
        //    }
        //    foreach (var p3 in registers)
        //    {
        //        pet1.Add(p3.petname3);
        //    }
        //    foreach (var p4 in registers)
        //    {
        //        pet1.Add(p4.petname4);
        //    }
        //    foreach (var p5 in registers)
        //    {
        //        pet1.Add(p5.petname5);
        //    }

        //    //LBx_Pets.ItemsSource = registers;
        //    var newList = pet1.Concat(pet2).Concat(pet3).Concat(pet4).Concat(pet5);
        //    LBx_OwnerPets.ItemsSource = newList;

        //}
        private void Breedfill()
        {
            ObservableCollection<string> ocBreed = new ObservableCollection<string>();
            ocBreed.Add("--Select--");
            ocBreed.Add("Labrador Retriever");
            ocBreed.Add("Spaniel (Cocker)");
            ocBreed.Add("French Bulldog");
            ocBreed.Add("Spaniel (English Springer)");
            ocBreed.Add("Pug ");
            ocBreed.Add("German Shepherd");
            ocBreed.Add("Bulldog");
            ocBreed.Add("Golden Retriever");
            ocBreed.Add("Border Terrier ");
            ocBreed.Add("Miniature Schnauzer ");
            ocBreed.Add("Staffordshire Bull Terrier");
            ocBreed.Add("Cavalier King Charles Spaniel");
            ocBreed.Add("Chihuahua ");
            ocBreed.Add("Boxer");
            ocBreed.Add("Dachshund");
            ocBreed.Add("Whippet ");
            ocBreed.Add("Lhasa Apso");
            ocBreed.Add("White Terrier");
            ocBreed.Add("Beagle");
            Cbo_breed1.ItemsSource = ocBreed;

            Cbo_breed1.SelectedItem = "--Select--";
        }
        //private void Btn_sort_Click(object sender, RoutedEventArgs e)
        //{
        //    var lst = from s in registers orderby s.firstName select s;
        //    LBx_Owner.ItemsSource = lst;
        //}

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Clear();

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (LBx_Owner.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to be deleted...:-(");
                return;
            }
            
            
            
            registers.Remove(LBx_Owner.SelectedItem as register);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Mystorage.WriteToXmlFile<ObservableCollection<register>>("registers.xml", registers);
        }

        void Clear()
        {
            Txt_fname.Clear();
            Txt_lname.Clear();
            Txt_address.Clear();
            Txt_city.Clear();
            Txt_email.Clear();
            Txt_telefon.Clear();
            Txt_name1.Clear();
            //Txt_fname.Focus();
            LBx_Pets.ItemsSource ="";
            LBx_Owner.SelectedItem = -1;
        }


        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Txt_name1.Text) || String.IsNullOrEmpty(Txt_fname.Text) || String.IsNullOrEmpty(Txt_lname.Text))
            {
                MessageBox.Show("Please fill the information");
            }
            else
            {

                registers.Add(new register { firstName = Txt_fname.Text, lastName = Txt_lname.Text, address = Txt_address.Text, city = Txt_city.Text, email = Txt_email.Text, telefon = Txt_telefon.Text, regdate = txtDatePicker.Text });
                //var pet = new pet { petname = Txt_name1.Text, petbreed = Cbo_breed1.SelectedItem.ToString(), petgender = Cbo_gender1.Text };
                pets.Add(new pet { ownerName = Txt_fname.Text, petname = Txt_name1.Text, petbreed = Cbo_breed1.SelectedItem.ToString(), petgender = Cbo_gender1.Text });
                Mystorage.WriteToXmlFile<ObservableCollection<register>>("registers.xml", registers);
                Mystorage.WriteToXmlFile<ObservableCollection<pet>>("pets.xml", pets);
                pets = Mystorage.ReadFromXmlFile<ObservableCollection<pet>>("pets.xml");
                LBx_Pets.ItemsSource = from p in pets where p.ownerName == Txt_fname.Text
                                       select p;

                LBx_Owner.SelectedItem = registers;
                LBx_Pets.ItemsSource = pets;
            }
        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            Mystorage.WriteToXmlFile<ObservableCollection<register>>("registers.xml", registers);
            MessageBox.Show("Updated Successfully :)");

        }

        private void TBx_filter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var filter = from r in registers where r.firstName.ToUpper().StartsWith(TBx_filter.Text.ToUpper()) select r;
            LBx_Owner.ItemsSource = filter;
        }

       
        private void Daysfill()
        {
            ObservableCollection<string> ocDays = new ObservableCollection<string>();
            ocDays.Add("Monday");
            ocDays.Add("Tuesday");
            ocDays.Add("Wednesday");
            ocDays.Add("Thursday");
            ocDays.Add("Friday");
            ocDays.Add("Saturday");
            //Cbo_days.ItemsSource = ocDays;
            // Cbo_days.SelectedItem = "--Select--";
        }

        private void Statusfill()
        {
            ObservableCollection<string> ocStatus = new ObservableCollection<string>();
            ocStatus.Add("Present");
            ocStatus.Add("Absent");
            Cbo_status.ItemsSource = ocStatus;

        }

            private void lbx_AssignPet_Selected(object sender, RoutedEventArgs e)
        {
            lbx_AssignPet.Items.Add(LBx_OwnerPets.SelectedItem);
        }


        private void lbx_AssignPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbx_AssignPet.Items.Add(LBx_OwnerPets.SelectedItem);
        }

        private void Cbo_class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LBx_attendance.ItemsSource = sessions.Where(x => x.sessionsname == Cbo_class.SelectedItem.ToString()).Select(x => x);
        }

        private void LBx_Owner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                pets = Mystorage.ReadFromXmlFile<ObservableCollection<pet>>("pets.xml");
                LBx_Pets.ItemsSource = from p in pets where p.ownerName == ((Pet_Training_App.register)LBx_Owner.SelectedItem).firstName select p;

                var date = (from r in registers where r.firstName == ((Pet_Training_App.register)LBx_Owner.SelectedItem).firstName select r.regdate).ToList();
                txtDatePicker.Text = date[0];
            }
            catch (Exception ex)
            {

                //throw;
            }
           
        }

        private void Attendence_Click(object sender, RoutedEventArgs e)
        { //List<string> pets = new List<string>();
            List<string> lpet2 = new List<string>();
           // foreach (var pet in LBx_attendance.Items)
           // {
           //     pets.Add(((Pet_Training_App.session)pet).petname);

           //}
            foreach (var pet2 in LBx_attendance.SelectedItems)
            {
                lpet2.Add(((Pet_Training_App.session)pet2).petname);

            }
            foreach (var att in LBx_attendance.Items) {
                if (lpet2.Contains(((Pet_Training_App.session)att).petname))
                {
                    attendances.Add(new attendance { classs = Cbo_class.SelectedValue.ToString(), Date = txtAttendenceDate.Text, status = "Present", petname = ((Pet_Training_App.session)att).petname });
                }
                else {
                    attendances.Add(new attendance { classs = Cbo_class.SelectedValue.ToString(), Date = txtAttendenceDate.Text, status = "Absent", petname = ((Pet_Training_App.session)att).petname });
                }
            }
            //  
            //foreach (var item in mainlist)
            //{
            //    attendances.Add(new attendance { classs = Cbo_class.SelectedValue.ToString(), Date = txtAttendenceDate.Text, status = "Absent", petname = item });
            //}

            MessageBox.Show("Attendance taken successfully");
            Mystorage.WriteToXmlFile<ObservableCollection<attendance>>("attendances.xml", attendances,true);
        }

       

        private void btnSaveTraining_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lbx_AssignPet.Items.Count; i++)
            {
                var data = new session { petname = ((Pet_Training_App.pet)lbx_AssignPet.Items[i]).petname, sessionsname = Cbo_tclass.SelectedItem.ToString() };
                sessions.Add(data);
                MessageBox.Show("Saved successfully.");

            }
            Mystorage.WriteToXmlFile<ObservableCollection<session>>("sessions.xml", sessions);
            lbx_AssignPet.Items.Clear();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            lbx_AssignPet.Items.Remove(lbx_AssignPet.SelectedItem);
            
        }

        private void Cbo_filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LBx_attendenceList.ItemsSource = from a in attendances where a.classs.Equals(Cbo_filter.SelectedValue.ToString()) select a;
        }

        private void Btn_pet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pets.Add(new pet { ownerName = Txt_fname.Text, petname = Txt_name1.Text, petbreed = Cbo_breed1.SelectedItem.ToString(), petgender = Cbo_gender1.Text });


                Mystorage.WriteToXmlFile<ObservableCollection<pet>>("pets.xml", pets);
                LBx_Pets.ItemsSource = from p in pets
                                       where p.ownerName == Txt_fname.Text
                                       select p;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Your Inputs");
                //throw;
            }
          
             
            //  Txt_name1.Clear();

        }

        private void TBx_OwnerFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = from r in pets where r.petname.ToUpper().StartsWith(TBx_OwnerFilter.Text.ToUpper()) select r;
            LBx_OwnerPets.ItemsSource = filter;
        }

        private void Btn_deletePet_Click(object sender, RoutedEventArgs e)
        {
            if (LBx_Pets.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to be deleted...:-(");
                return;
            }
            pets.Remove(LBx_Pets.SelectedItem as pet);
            LBx_Pets.ItemsSource = from p in pets
                                   where p.ownerName == Txt_fname.Text
                                   select p;

        }

        private void Txt_pet_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = from r in attendances where r.petname.ToUpper().StartsWith(Txt_pet_filter.Text.ToUpper()) select r;
            LBx_attendenceList.ItemsSource = filter;
        }

        private void Cbo_status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var filter = from r in attendances where r.status.ToUpper().StartsWith(Cbo_status.SelectedItem.ToString().ToUpper()) select r;
            LBx_attendenceList.ItemsSource = filter;

        }
    }

}
