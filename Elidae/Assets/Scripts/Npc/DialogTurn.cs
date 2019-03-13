using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;

namespace Assets.Scripts.Npc
{
    public class DialogTurn
    {
        public bool FirstToTalk = true;
        public int NpcDialogLenght;
        public int PlayerDialogLenght;
        public int NTurn = 0;
        public int PTurn = 0;
        public TextMeshProUGUI Dialog;
        public TextMeshProUGUI DialogName;
        public bool PlayerTurn;


        public void Default()
        {
            NTurn = 0;
            PTurn = 0;
            FirstToTalk = true;

        }
    }
}
