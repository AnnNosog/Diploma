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
    }
}
