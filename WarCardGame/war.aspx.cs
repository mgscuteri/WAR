using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace warSpace
{
    public partial class war : System.Web.UI.Page
    {
        public static Deck cardDeck;
        public static int nextCardIndex;
        public static int playerScore;
        public static int computerScore;
        public static int newGame;
        public static Player player;
        public static Player computer;
        public static Card playerCard0;
        public static Card computerCard0;   

        protected void Page_Load(object sender, EventArgs e)
       { 
            if (!Page.IsPostBack || newGame == 2)
            {
                //innitialize and shuffle deck
                newGame = 1;              
                cardDeck = new Deck();
                player = new Player();
                computer = new Player();
                //Deal Even cards to player 
                for (int i = 2; i <= 53; i = i + 2) { player.cards.Add(cardDeck.cards[i]); }
                //Deal Odd Cards to Computer
                for (int i = 3; i <= 53; i = i + 2) { computer.cards.Add(cardDeck.cards[i]); }
                //Display player hand sizes 
                playerStack.Text = player.cards.Count().ToString();
                computerStack.Text = computer.cards.Count().ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (player.cards.Count() > 0 && computer.cards.Count() > 0) 
            {
                Card playerCard = player.cards[0].duplicateCard();
                Card computerCard = computer.cards[0].duplicateCard();
                player.cards.RemoveAt(0);
                computer.cards.RemoveAt(0);

                //Display Player Card
                playerCardImage.Visible = true;
                playerCardImage.ImageUrl = playerCard.url;
                //Display Computer Card
                computerCardImage.Visible = true;
                computerCardImage.ImageUrl  = computerCard.url;                 

                //Determine the winner
                if (playerCard.value > computerCard.value)
                {
                    winLossTracker.Text = "Victory!";
                    player.cards.Add(playerCard);
                    player.cards.Add(computerCard);                    
                }
                else if (playerCard.value < computerCard.value)
                {
                    winLossTracker.Text = "Defeat!";
                    computer.cards.Add(computerCard);
                    computer.cards.Add(playerCard);                    
                    
                }
                else //WAR
                {
                    winLossTracker.Text = "War!";
                    //Hide Draw Button, show war button 
                    Button1.Visible = false;
                    warButton.Visible = true;
                    //save cards in play for use in war function
                    playerCard0 = playerCard.duplicateCard();
                    computerCard0 = computerCard.duplicateCard();
                }

                //Display player hand sizes 
                playerStack.Text = player.cards.Count().ToString();
                computerStack.Text = computer.cards.Count().ToString();

                //Display a random motivational message
                List<string> textMessages = new List<string>() { "Click it again.", "One more time.", "Are you feeling lucky?", "Pretty tough eh?", "There's only one button.", "Oooo, you're doing well.", "Don't Stop now!", "That was a good click.", "I think you're going to win this next one." };
                Random rr = new Random();
                bodyText.Text = textMessages[rr.Next(0, textMessages.Count() - 1)];

                //Hide any war card slots
                playerWarCard1.Visible = false;                
                playerWarCard2.Visible = false;                
                computerWarCard1.Visible = false;                
                computerWarCard2.Visible = false;
            }
            else //Process win/loss and reset
            {   
                winLossTracker.Text = "";
                if (player.cards.Count() > 0)
                {
                    finalResult.Text = "YOU WIN!";
                    player.winCount++;
                }
                else
                {
                    finalResult.Text = "YOU LOSE!";
                    computer.winCount++; 
                }
                playerWinsLabel.Text = player.winCount.ToString();
                computerWinsLabel.Text = computer.winCount.ToString();
                Button1.Visible = false;
                Button2.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)  //WAR!!!!
        {
            //At the moment only 1 instance of war is supported. A subsequent is quite possible but likely. 
            //put a while(!WAR) here to support War^2

            if (player.cards.Count > 1 && computer.cards.Count > 1)
            {

                Card playerCard1 = player.cards[0].duplicateCard();
                Card playerCard2 = player.cards[1].duplicateCard();
                Card computerCard1 = computer.cards[0].duplicateCard();
                Card computerCard2 = computer.cards[1].duplicateCard();

                player.cards.RemoveAt(0);
                computer.cards.RemoveAt(0);
                player.cards.RemoveAt(0);
                computer.cards.RemoveAt(0);

                playerWarCard1.ImageUrl = @"/cards/_faceDown.png";
                playerWarCard1.Visible = true;
                playerWarCard2.ImageUrl = playerCard2.url;
                playerWarCard2.Visible = true;
                computerWarCard1.ImageUrl = @"/cards/_faceDown.png";
                computerWarCard1.Visible = true;
                computerWarCard2.ImageUrl = computerCard2.url;
                computerWarCard2.Visible = true;

                if (playerCard2.value > computerCard2.value)
                {
                    winLossTracker.Text = "Major Victory!";
                    player.cards.Add(playerCard0);
                    player.cards.Add(playerCard1);
                    player.cards.Add(playerCard2);
                    player.cards.Add(computerCard0);
                    player.cards.Add(computerCard1);
                    player.cards.Add(computerCard2);
                }
                else if (playerCard2.value < computerCard2.value)
                {
                    winLossTracker.Text = "Major Defeat!";
                    computer.cards.Add(computerCard0);
                    computer.cards.Add(computerCard1);
                    computer.cards.Add(computerCard2);
                    computer.cards.Add(playerCard0);
                    computer.cards.Add(playerCard1);
                    computer.cards.Add(playerCard2);
                }
                else
                {
                    winLossTracker.Text = "A Very Unlikely Tie..";
                }

                //Display player hand sizes 
                playerStack.Text = player.cards.Count().ToString();
                computerStack.Text = computer.cards.Count().ToString();

                //hide war button, show draw button
                warButton.Visible = false;
                Button1.Visible = true;
            }
            else //A player does not have enough cards for war 
            {
                if (player.cards.Count() == 1)
                    player.cards.RemoveAt(0);
                else if (computer.cards.Count() == 1)
                    computer.cards.RemoveAt(0);

                Button1_Click(sender, e);
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            //Start a new game. Show draw button. Hide play again button. 
            newGame = 2;            
            Button1.Visible = true;
            Button2.Visible = false;
            finalResult.Text = "";
            playerCardImage.Visible = false;
            computerCardImage.Visible = false;
            playerWarCard1.Visible = false;
            playerWarCard2.Visible = false;
            computerWarCard1.Visible = false;
            computerWarCard2.Visible = false;            
        }
    }

    public class Card
    {
        public string name;
        public int value;
        public string url;
        public int deckPosition;

        public Card(string Name, int Value, string URL)
        {
            name = Name;
            value = Value;
            url = URL;
        }

        public Card duplicateCard()
        {
            Card tempCard = new Card(name, value, url);
            return tempCard;
        }
    }

    public class Player
    {
        public List<Card> cards;
        public int winCount;

        public Player()
        {
            cards = new List<Card>();
            winCount = 0;
        }
    }

    public class Deck
    {
        public Dictionary<int, Card> cards;

        public Deck()
        {
            cards = new Dictionary<int, Card>();
            Random r = new Random();

            Dictionary<int, int> cardOrder = new Dictionary<int, int>();

            //populate cardIndex, deckOrder list
            for(int i = 2; i < 54; i++)
            {
                cardOrder.Add(i, i);
            }

            //shuffle card indices
            for (int i = 0; i < 100; i++)
            {
                int cardOrder1 = 0;
                int cardOrder2 = 0;
                int index1 = 0;
                int index2 = 0; 
                                
                index1 = r.Next(2, 53);
                index2 = r.Next(2, 53);

                cardOrder1 = cardOrder[index1];
                cardOrder2 = cardOrder[index2];

                cardOrder[index2] = cardOrder1;
                cardOrder[index1] = cardOrder2;               
            }

            //Loop through all the image files in "cards" folder to populate "cards" dictionary 
            //i = card value
            //ii = suit
            //keyIndex = unique index for every card (and deckOrder)
            int keyIndex = 2;
            List<string> suits = new List<string>() { "c", "d", "h", "s" };

            for (int i = 2; i <= 14; i++) 
            {
                for(int ii = 0; ii < 4; ii++) // 1 = clubs 2 = diamonds 3 = hearts 4 = spades
                {
                    string currentCard = i.ToString() + suits[ii];
                    cards.Add(cardOrder[keyIndex], new Card(currentCard, i, @"/cards/" + currentCard +".png"));
                    keyIndex++;
                }   
            }
        }        
    }   
}