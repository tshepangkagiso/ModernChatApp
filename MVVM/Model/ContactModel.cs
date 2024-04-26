using System.Collections.ObjectModel;
using System.Linq;

namespace ModernChatApp.MVVM.Model
{
    class ContactModel
    {
        public string Username { get; set; }
        public string ImageSource { get; set; }

        public ObservableCollection<MessageModel> Messages { get; set; }
        public string LastMessage => Messages.Last().Message;


        /*
         An Observable Collection is a collection class in .NET programming that notifies the user interface when items 
         are added to or removed from the collection.

        It implements the INotifyCollectionChanged interface, which provides a mechanism for notifying the UI when 
        changes are made to the collection, such as adding or removing an item. This enables the UI to update itself 
        automatically without requiring manual intervention from the developer.

        Observable Collections are commonly used in data binding scenarios, where the data in the collection is displayed in a 
        UI element such as a list or a grid. When the data changes, the Observable Collection notifies the UI, which in turn 
        updates the display to reflect the changes.
        */
    }
}
