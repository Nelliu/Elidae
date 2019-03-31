using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Quest.QuestMaker
{
    public class QuestMaker : EditorWindow
    {
        private static string qname; // Quest name
        private static string desc; // Quest description
        private static int selectedReward; // selection between gold or item reward
        private static int typeSelected; // selection between talking quest and killing one, talking only one working now -- WIP
        private static int countNeeded = 1; // automatically 1 if talking is needed, this can be changed in future 
        private static int xp; // defines how much xp you get for quest completition


        private static string npcName; // name of npc to talk to get a q 
        private static string npcTarget; // npc to talk to to finish q or enemies to kill

        private static int reward; // reward between gold or item

        [MenuItem("Window/Quest Making")]

        public static void ShowWindow()
        {
            GetWindow<QuestMaker>("Quest Making"); // shows window for quest making
        }

        private void OnGUI()
        {
            qname = EditorGUILayout.TextField("Quest name", qname);
            desc = EditorGUILayout.TextField("Description", desc);
            string[] options = new string[] { "Talk to", "Kill enemy/enemies - NotWorking"};

            typeSelected = EditorGUILayout.Popup("Type", typeSelected, options);
            npcName = EditorGUILayout.TextField("Npc name - gives Q", npcName);
            if (typeSelected == 0 )
            {
                
                npcTarget = EditorGUILayout.TextField("Npc name - finishes Q", npcTarget);
            }
            else if (typeSelected == 1)
            {
                npcTarget = EditorGUILayout.TextField("Npc name - kill those", npcTarget);
                countNeeded = EditorGUILayout.IntField("Count needed", countNeeded);
            }

            xp = EditorGUILayout.IntField("XP Reward", xp);

            string[] optionz = new string[] { "Gold reward", "Item reward" };

            selectedReward = EditorGUILayout.Popup("Quest reward", selectedReward, optionz); 
             
            if (selectedReward == 0)
            {
                reward = EditorGUILayout.IntField("Gold reward", reward);
            }
            else if (selectedReward == 1)
            {
                reward = EditorGUILayout.IntField("Item ID reward", reward);
            }

            if (GUILayout.Button("Save quest"))
            {



                SaveSystem.SaveQuest(questcreation());
            }   

        }


        private static AQuest questcreation()
        {
            AQuest returning;
            Quest quest = new Quest();
            
            quest.QuestName = qname;
            quest.Complete = false;
            
            quest.CurrentCount = 0;
            quest.Description = desc;
            quest.QuestType = typeSelected;
            quest.Reward = reward;
            quest.NpcName = npcName;
            quest.NpcTarget = npcTarget;
            quest.XpReward = xp;
            

            if (typeSelected == 0)
            {
                quest.CountNeeded = 1;
            }
            else if (typeSelected == 1)
            {
                quest.CountNeeded = countNeeded;
            }
            returning = quest;
            return returning;
        }






    }
}
