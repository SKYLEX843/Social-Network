using System;
using System.Collections.Generic;
using System.Linq;

public class SocialNetwork
{
    private Dictionary<string, List<string>> network;
    public SocialNetwork()
    {
        network = new Dictionary<string, List<string>>();
    }
    public void AddUser(string name)
    {
        if (network.ContainsKey(name))
        {
            Console.WriteLine($"{name} already exists.");
        }
        else
        {
            network[name] = new List<string>();
            Console.WriteLine($"{name} has been added.");
        }
    }
    public Dictionary<string, List<string>> GetNetwork()
    {
        return network;
    }
    public void RemoveUser(string name)
    {
        if (!network.ContainsKey(name))
        {
            Console.WriteLine($"{name} does not exist.");
        }
        else
        {
            foreach (var friend in network[name])
            {
                network[friend].Remove(name);
            }
            network.Remove(name);
            Console.WriteLine($"{name} has been removed from the network.");
        }
    }
    public void AddFriend(string user1, string user2)
    {
        if (!network.ContainsKey(user1) || !network.ContainsKey(user2))
        {
            Console.WriteLine("One or both users do not exist.");
        }
        else if (network[user1].Contains(user2))
        {
            Console.WriteLine($"{user1} and {user2} are already friends.");
        }
        else
        {
            network[user1].Add(user2);
            network[user2].Add(user1);
            Console.WriteLine($"{user1} and {user2} are now friends.");
        }
    }
    public void RemoveFriend(string user1, string user2)
    {
        if (!network.ContainsKey(user1) || !network.ContainsKey(user2))
        {
            Console.WriteLine("One or both users do not exist.");
        }
        else if (!network[user1].Contains(user2))
        {
            Console.WriteLine($"{user1} and {user2} are not friends.");
        }
        else
        {
            network[user1].Remove(user2);
            network[user2].Remove(user1);
            Console.WriteLine($"{user1} and {user2} are no longer friends.");
        }
    }
    public void DisplayFriends(string user)
    {
        if (!network.ContainsKey(user))
        {
            Console.WriteLine($"{user} does not exist.");
        }
        else if (network[user].Count == 0)
        {
            Console.WriteLine($"{user} has no friends.");
        }
        else
        {
            Console.WriteLine($"{user}'s friends: {string.Join(", ", network[user])}");
        }
    }
    public void FindMutualFriends(string user1, string user2)
    {
        if (!network.ContainsKey(user1) || !network.ContainsKey(user2))
        {
            Console.WriteLine("One or both users do not exist.");
        }
        else
        {
            var mutualFriends = network[user1].Intersect(network[user2]).ToList();
            if (mutualFriends.Count == 0)
            {
                Console.WriteLine($"{user1} and {user2} have no mutual friends.");
            }
            else
            {
                Console.WriteLine($"Mutual friends of {user1} and {user2}: {string.Join(", ", mutualFriends)}");
            }
        }
    }
    public void SuggestFriends(string user)
    {
        if (!network.ContainsKey(user))
        {
            Console.WriteLine($"{user} does not exist.");
        }
        else
        {
            var suggestions = new List<string>();
            var userFriends = network[user];
            foreach (var friend in userFriends)
            {
                foreach (var potentialFriend in network[friend])
                {
                    if (potentialFriend != user && !userFriends.Contains(potentialFriend) && !suggestions.Contains(potentialFriend))
                    {
                        suggestions.Add(potentialFriend);
                    }
                }
            }
            if (suggestions.Count == 0)
            {
                Console.WriteLine($"No friend suggestions for {user}.");
            }
            else
            {
                Console.WriteLine($"Friend suggestions for {user}: {string.Join(", ", suggestions)}");
            }
        }
    }

    // Main method 
    public static void Main(string[] args)
    {
        SocialNetwork sn = new SocialNetwork();

        sn.AddUser("Alice"); 
        sn.AddUser("Bob"); 
        sn.AddUser("Charlie"); 
        sn.AddUser("Alice"); 
        sn.RemoveUser("Charlie"); 
        sn.AddFriend("Alice", "Bob"); 
        sn.RemoveUser("Bob"); 
        sn.AddUser("Bob"); 
        sn.AddFriend("Alice", "Bob"); 
        sn.RemoveFriend("Alice", "Bob"); 
        sn.AddFriend("Alice", "Bob"); 
        sn.DisplayFriends("Alice"); 
        sn.AddUser("Charlie"); 
        sn.AddFriend("Alice", "Charlie"); 
        sn.AddFriend("Bob", "Charlie"); 
        sn.FindMutualFriends("Alice", "Bob"); 

        sn.SuggestFriends("Alice"); 
    }
}
