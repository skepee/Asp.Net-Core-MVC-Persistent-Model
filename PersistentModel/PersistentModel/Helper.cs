using PersistentModel.Models;

namespace PersistentModel
{
    public static class Helper
    {
        private static MyModel MyModelInController { get; set; }

        public static MyModel Sync(this MyModel myModel)
        {
            if (myModel.Message!=null)
                MyModelInController.Message = myModel.Message;

            if (MyModelInController.Name == null && myModel.Name != null)
                MyModelInController.Name = myModel.Name;

            if (MyModelInController.Surname == null && myModel.Surname != null)
                MyModelInController.Surname = myModel.Surname;

            if (MyModelInController.NumChildren == 0 && myModel.NumChildren != 0)
                MyModelInController.NumChildren = myModel.NumChildren;

            if (MyModelInController.Children.Count == 0 && myModel.Children.Count>0)
                MyModelInController.Children = myModel.Children;

            return MyModelInController;
        }

        public static void Init()
        {
            MyModelInController = new MyModel();
        }

    }
}
