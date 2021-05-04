namespace Diploma.Strategy
{
    class SecondWorkerQuery : IWorkerQuery
    {
        public string LoadQuery { get => @"Select Tasks.Task_id, Profiles.Article, Process.Process_id, SUM(Process_worker.Quantity) As Quantity
                                From Process_worker Join Process
                                ON Process.Process_id = Process_worker.Process_id
                                Join Users
                                ON Process_worker.User_id = Users.User_id
                                Join Tasks
                                ON Process.Task_id = Tasks.Task_id
                                Join Profiles
                                ON Process.Profile_id=Profiles.Profile_id
                                Where Users.Role_id = 2
                                Group by Process.Process_id, Tasks.Task_id, Profiles.Article
                                Order by Process.Process_id"; }

        public int RileID { get => 3; }

        public string GetQuatityQuery(int quantity)
        {
            return $"Select Process_worker.Quantity From Process_worker Join Process ON Process_worker.Process_id = Process.Process_id Join Users ON Process_worker.User_id = Users.User_id Join Roles ON Users.Role_id = Roles.Role_id Where Roles.Role_id = 3 AND Process_worker.Process_id = {quantity}";
        }

        public string GetTextWindow()
        {
            return "Упаковщики";
        }
    }
}
