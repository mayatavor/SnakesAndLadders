using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

struct Square
{
    public int m_square_id;
    public int m_to_id;

    public Square(int s_id, int t_id)
    {
        this.m_square_id = s_id;
        this.m_to_id = t_id;
    }
}

namespace snakes_and_ladders
{
    public partial class MainWindow : Window
    {
        private Square[] special;
        private int[] special_numbers;
        private Random rand = new Random();
        private int dice_num_now;
        private bool is_player_1;
        private bool have_won;

        private int player1_place;
        private int player2_place;
        public MainWindow()
        {
            InitializeComponent();

            this.special = new Square[6];
            this.special[0] = new Square(6, 18);
            this.special[1] = new Square(10, 4);
            this.special[2] = new Square(12, 25);
            this.special[3] = new Square(15, 28);
            this.special[4] = new Square(30, 17);
            this.special[5] = new Square(34, 26);

            this.special_numbers = new int[6] { 6, 10, 12, 15, 30, 34 };
            this.dice_num_now = 6;
            this.have_won = false;
            this.is_player_1 = true;

            this.player1_place = 0;
            this.player2_place = 0;


        }
        public void StartGame()
        {
            while(!this.have_won)
            {
                RollDiceAsync();

                if(this.is_player_1)
                {

                }





                if (this.player1_place == 36 || this.player2_place == 36)
                    this.have_won = true;
            }






        }

        public async Task RollDiceAsync()
        {
            int new_num = rand.Next(2, 7); // needs fixing
            int now = this.dice_num_now;
            int time_until_change = 150;
            int i = 0;

            switch (this.dice_num_now)
            {
                case 1:
                    this.dice1.Source = GetImage("Assets/dice1.png");
                    this.dice1.Height = 50;
                    break;
                case 2:
                    this.dice2.Source = GetImage("Assets/dice2.png");
                    this.dice2.Height = 50;
                    break;
                case 3:
                    this.dice3.Source = GetImage("Assets/dice3.png");
                    this.dice3.Height = 50;
                    break;
                case 4:
                    this.dice4.Source = GetImage("Assets/dice4.png");
                    this.dice4.Height = 50;
                    break;
                case 5:
                    this.dice5.Source = GetImage("Assets/dice5.png");
                    this.dice5.Height = 50;
                    break;
                case 6:
                    this.dice6.Source = GetImage("Assets/dice6.png");
                    this.dice6.Height = 50;
                    break;
                default:
                    break;
            }

            this.start.Content = new_num.ToString();

            while (i < 8 || now + i != new_num) 
            {
                if (now + i > 6)
                    now -= 6;

                if (i > 6)
                {
                    time_until_change = 300;
                   //if (now + i == new_num)
                        //now -= 4;
                }

                switch (now + i)
                {
                    case 1:
                        this.dice2.Source = GetImage("Assets/gold2.png");
                        this.dice2.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice2.Source = GetImage("Assets/dice2.png");
                        this.dice2.Height = 50;
                        break;
                    case 2:
                        this.dice3.Source = GetImage("Assets/gold3.png");
                        this.dice3.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice3.Source = GetImage("Assets/dice3.png");
                        this.dice3.Height = 50;
                        break;
                    case 3:
                        this.dice4.Source = GetImage("Assets/gold4.png");
                        this.dice4.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice4.Source = GetImage("Assets/dice4.png");
                        this.dice4.Height = 50;
                        break;
                    case 4:
                        this.dice5.Source = GetImage("Assets/gold5.png");
                        this.dice5.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice5.Source = GetImage("Assets/dice5.png");
                        this.dice5.Height = 50;
                        break;
                    case 5:
                        this.dice6.Source = GetImage("Assets/gold6.png");
                        this.dice6.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice6.Source = GetImage("Assets/dice6.png");
                        this.dice6.Height = 50;
                        break;
                    case 6:
                        this.dice1.Source = GetImage("Assets/gold1.png");
                        this.dice1.Height = 60;
                        await Task.Delay(time_until_change);
                        this.dice1.Source = GetImage("Assets/dice1.png");
                        this.dice1.Height = 50;
                        break;
                    default:
                        break;
                }

                i++;


            }//end of for

            switch (new_num)
            {
                case 1:
                    this.dice1.Source = GetImage("Assets/gold1.png");
                    this.dice1.Height = 60;
                    break;
                case 2:
                    this.dice2.Source = GetImage("Assets/gold2.png");
                    this.dice2.Height = 60;
                    break;
                case 3:
                    this.dice3.Source = GetImage("Assets/gold3.png");
                    this.dice3.Height = 60;
                    break;
                case 4:
                    this.dice4.Source = GetImage("Assets/gold4.png");
                    this.dice4.Height = 60;
                    break;
                case 5:
                    this.dice5.Source = GetImage("Assets/gold5.png");
                    this.dice5.Height = 60;
                    break;
                case 6:
                    this.dice6.Source = GetImage("Assets/gold6.png");
                    this.dice6.Height = 60;
                    break;
                default:
                    break;
            }

            this.dice_num_now = new_num;


        }

        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            return bitmapImage;
        }


        public async Task WalkCharacterAsync(bool player1)
        {
            int now = this.player1_place;
            string starting = "h";
            string img_id = "h" + this.player1_place.ToString();
            BitmapImage character = GetImage("Assets/helmet.png");
            BitmapImage empty = GetImage("Assets/empty.png");
            if (!player1)
            {
                now = this.player2_place;
                img_id = "b" + this.player2_place.ToString();
                starting = "b";
                character = GetImage("Assets/basketball.png");
            }

            Image n = (Image)this.Images.FindName(img_id);
            n.Source = empty;


            for (int i = now + 1; i < this.dice_num_now + now + 1; i++)
            {
                img_id = starting + i.ToString();
                n = (Image)this.Images.FindName(img_id);

                n.Source = character;
                await Task.Delay(250);
                n.Source = empty;
            }

            n.Source = character;

            if (player1)
            {
                if (this.player1_place == 1)
                    this.player1_place = this.dice_num_now;
                else
                    this.player1_place += this.dice_num_now;
            }
            else
            {
                if (this.player2_place == 1)
                    this.player2_place = this.dice_num_now;
                else
                    this.player2_place += this.dice_num_now;
            }

        }

        public async Task ClimbOrSlideCharacterAsync(bool player1)
        {

        }


        private async void start_Click(object sender, RoutedEventArgs e)
        {
            //this.start.IsEnabled = false;
            await RollDiceAsync();
            await WalkCharacterAsync(true);
        }
    }
}
