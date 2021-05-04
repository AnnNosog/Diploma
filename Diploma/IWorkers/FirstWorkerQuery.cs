namespace Diploma.Strategy
{
    class FirstWorkerQuery : IWorkerQuery
    {
        public string LoadQuery { get => @"Select Tasks.Task_id, Profiles.Article, Process.Process_id, Process.Quantity
                                 From Tasks Join Process
                                 ON Tasks.Task_id=Process.Task_id
                                 JOIN Profiles
                                 ON Process.Profile_id = Profiles.Profile_id
                                 Join Users
                                 ON Tasks.User_id = Users.User_id
                                 Join Roles
                                 ON Users.Role_id = Roles.Role_id
                                 WHERE Roles.Name = 'Chief'"; }

        public string GetQuatityQuery(int quantity)
        {
            return $"Select Process_worker.Quantity From Process_worker Join Process ON Process_worker.Process_id = Process.Process_id Join Users ON Process_worker.User_id = Users.User_id Join Roles ON Users.Role_id = Roles.Role_id Where Roles.Role_id != 3 AND Process_worker.Process_id = {quantity}";
        }

        public string GetTextWindow()
        {
            return "Первая смена";
        }
    }
}
