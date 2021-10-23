using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyObject
{
    public class Policy
    {
        public string name { get; set; }
        public int cost { get; set; }
        public List<string> requires { get; set; }
        public List<(string Name, int Value)> actions { get; set; }
        public string feedback { get; set; }
    }

    //public List<Policy> ParsePolicies(TextAsset textAsset, string delimeter)
    //{
    //    string text = textAsset.text.Trim();
    //    string[] policyData = text.Split(new string[] { delimeter }, StringSplitOptions.None);

    //    List<Policy> policies = new List<Policy>();
    //    for (int i = 1; i < policyData.Length; i++)
    //    {
    //        string[] policyDetails = policyData[i].Split(new string[] { "," }, StringSplitOptions.None);
    //        Debug.Log("prereq " + policyDetails[2]);
    //        string policyName = policyDetails[0];
    //        int policyCost = Int32.Parse(policyDetails[1]);

    //        string requirement = policyDetails[2];
    //        int progress = Int32.Parse(policyDetails[3]);
    //        int money = Int32.Parse(policyDetails[4]);

    //        Policy policy = new Policy();
    //        policy.name = policyName;
    //        policy.cost = policyCost;

    //        policy.actions = new List<(string Name, int Value)>();

    //        policy.actions.Add(("progress", progress));
    //        policy.actions.Add(("money", money));

    //        policy.requires = new List<string>();
    //        if (requirement != "none")
    //        {
    //            policy.requires.Add(requirement);
    //        }

    //        // Feedback
    //        string feedback = "";
    //        if (policyDetails.Length > 5)
    //        {
    //            feedback = policyDetails[5];
                
    //        }
    //        policy.feedback = feedback;
    //        Debug.Log("Assigned feedback: " + policy.feedback);

    //        policies.Add(policy);
    //    }

    //    return policies;
    //}
}