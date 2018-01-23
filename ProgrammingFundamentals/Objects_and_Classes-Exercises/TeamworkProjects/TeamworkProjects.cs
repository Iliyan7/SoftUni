using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    public class TeamworkProjects
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                var creatorAndTeam = Console.ReadLine().Split('-');

                RegisterTeam(teams, creatorAndTeam[0], creatorAndTeam[1]);
            }

            while (true)
            {
                var userAndTeam = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.None);

                if (userAndTeam[0] == "end of assignment")
                    break;

                MemberWantToJoin(teams, userAndTeam[0], userAndTeam[1]);
            }

            foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                if (team.Members.Count == 0)
                    continue;

                Console.WriteLine(team.TeamName);
                Console.WriteLine("- {0}", team.CreatorName);
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine("-- {0}", member);
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teams.OrderBy(x => x.TeamName))
            {
                if (team.Members.Count == 0)
                    Console.WriteLine(team.TeamName);
            }
        }

        public static void RegisterTeam(List<Team> teams, string userCreator, string teamName)
        {
            if (teams.Any(x => x.TeamName == teamName))
            {
                Console.WriteLine("Team {0} was already created!", teamName);
                return;
            }

            if (teams.Any(x => x.CreatorName == userCreator))
            {
                Console.WriteLine("{0} cannot create another team!", userCreator);
                return;
            }

            teams.Add(new Team() { TeamName = teamName, Members = new List<string>(), CreatorName = userCreator });
            Console.WriteLine("Team {0} has been created by {1}!", teamName, userCreator);
        }

        public static void MemberWantToJoin(List<Team> teams, string member, string teamName)
        {
            if (!teams.Any(x => x.TeamName == teamName))
            {
                Console.WriteLine("Team {0} does not exist!", teamName);
                return;
            }

            if (teams.Any(x => x.Members.Contains(member)) || teams.Any(x => x.CreatorName == member))
            {
                Console.WriteLine("Member {0} cannot join team {1}!", member, teamName);
                return;
            }

            var index = teams.FindIndex(x => x.TeamName == teamName);
            teams[index].Members.Add(member);
        }
    }
}
