#include <iostream>
#include <cctype>

void GetDevInfo();
void GreetPlayer();
void BlankLines(int n);
void ShowLives(int lives);

int main()
{
    GetDevInfo();
    GreetPlayer();

    int Lives = 4;
    int Wins = 0, Loses = 0;

    int Guess = 0;
    int correctNumber;

    while (true) {
        correctNumber = std::rand() % 10 + 1;

        std::cout << "Guess the number between 1 to 10." << std::endl;
        ShowLives(Lives);
        while (true) {
            std::cin >> Guess;
            BlankLines(1);
            if (std::cin.fail()) {
                std::cout << "Please enter a number.";
                continue;
            }

            else if (Guess <= 0 and Guess > 10) {
                std::cout << "Please enter the number between 1 to 10." << std::endl;
                continue;
            }

            else if (Guess == correctNumber) {
                Wins++;
                std::cout << "WoW! You have Guess the Correct Number {~ _ ~}" << std::endl;
                BlankLines(2);
                break;
            }

            Lives--;
            if (Lives <= 0) {
                Loses++;
                std::cout << "Correct Number: " << correctNumber << std::endl;
                std::cout << "OHH NO! You have loose all lives. :[" << std::endl;
                BlankLines(1);
                break;
            }
            std::cout << "Try Again to Guess the Number." << std::endl;
            ShowLives(Lives);
        }

        std::cout << "WINS:  " << Wins << "     LOSES:  " << Loses << std::endl;
        BlankLines(1);

        char playInput;
        std::cout << "Want to Play Again? :{ [Y or N]" << std::endl;
        std::cin >> playInput;
        BlankLines(2);

        if (std::toupper(playInput) == 'Y') {
            Lives = 4;
            continue;
        }

        else {
            break;
        }
    } 
}

void GetDevInfo() {
    std::string name = "Number Guessing";
    std::string version = "1.0.0";
    std::string author = "Amit Kumar";
    std::cout <<"\033[32m" << name << ": V " << version << " by " << author << "\033[0m" << std::endl << std::endl;
}

void GreetPlayer() {
    std::string Playerinput;
    while (true){
        std::cout << "Please Enter Your Name." << std::endl;
        std::cin >> Playerinput;
        BlankLines(1);

        if (Playerinput != "") {
            break;
        }
    }
    std::cout << "Hello " << Playerinput << "! Let's Play the Guess Game :}" << std::endl;
    BlankLines(1);
}

void BlankLines(int n) {
    for (int i = 0; i < n; i++) {
        std::cout << "" << std::endl;
    }
}

void ShowLives(int lives) {
    for (int l = 0; l < lives; l++) {
        std::cout << "@";
    }
    BlankLines(1);
}
