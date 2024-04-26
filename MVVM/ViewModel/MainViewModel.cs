using ModernChatApp.Core;
using ModernChatApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace ModernChatApp.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        //commands
        public RelayCommand SendCommand { get; set; }
        private ContactModel _selectedContact { get; set; }
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            {
                _selectedContact = value;
                onPropertyChanged();
            }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set 
            {  _message = value;
                onPropertyChanged(); 
            }
        }




        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });


            //its done this way because we dont have an api to pull data from, this is just for visibility on ui
            #region
            Messages.Add(new MessageModel
            {
                Username ="Allison",
                UsernameColor ="#409aff",
                ImageSource = "https://i.imgur.com/i2szTsp.png",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for(int i = 0; i < 3; i++)
            {

                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409aff",
                    ImageSource = "https://i.imgur.com/i2szTsp.png",
                    Message ="Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 4; i++)
            {

                Messages.Add(new MessageModel
                {
                    Username = "Steven",
                    UsernameColor = "Red",
                    ImageSource = "https://i.imgur.com/G4FzuHHb.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }


            Messages.Add(new MessageModel
            {
                Username = "Steven",
                UsernameColor = "Red",
                ImageSource = "https://i.imgur.com/G4FzuHHb.jpg",
                Message = "last",
                Time = DateTime.Now,
                IsNativeOrigin = true,
            });

            //populating contact list on ui
            //for(int i = 0; i < 5;i++)
            //{
            //    Contacts.Add(new ContactModel
            //    {
            //        Username =$"Allison {i}",
            //        ImageSource ="https://i.imgur.com/i2szTsp.png",
            //        Messages = Messages
            //    });
            //}

            Contacts.Add(new ContactModel
            {
                Username = "Allison",
                ImageSource = "https://i.imgur.com/i2szTsp.png",
                Messages = Messages
            });

            Contacts.Add(new ContactModel
            {
                Username = "Steven",
                ImageSource = "https://i.imgur.com/G4FzuHHb.jpg",
                Messages = Messages
            });
            #endregion




        }
    }
}
