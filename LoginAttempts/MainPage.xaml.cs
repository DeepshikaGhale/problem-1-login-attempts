namespace LoginAttempts;

public partial class MainPage : ContentPage
{
    //store the amount of attempts
    int totalAttemptsLeft = 5;
    //pre-defined password
    const string defaultPassword = "Test@123";

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnLoginPressed(object sender, EventArgs e)
    {
        //store user input
        var userInput = entry.Text;

        //validate if the input data is empty or not
        if (userInput == null || userInput == "")
        {
            errorMsg.Text = "Please enter a password.";
            errorMsg.IsVisible = true;
        }
        else
        {
            //compare
            if (userInput == defaultPassword)
            {
                errorMsg.Text = "";
                resultMsg.Text = "Welcome!";
                resultMsg.IsVisible = true;
                entry.IsReadOnly = true;
            }
            else
            {
                //if the password does not match
                errorMsg.Text = "Incorrect Password.";
                errorMsg.IsVisible = true;
                //check the amount of attempts left
                if (totalAttemptsLeft != 0)
                {
                    totalAttemptsLeft--;
                    attempts.Text = $"Attempts: {totalAttemptsLeft}/5";
                    //show response if the attempts is zero 
                    if (totalAttemptsLeft == 0)
                    {
                        resultMsg.Text = "You have been locked out.";
                        resultMsg.IsVisible = true;
                        entry.IsReadOnly = true;
                    }
                }
            }
        }

        SemanticScreenReader.Announce(LoginBtn.Text);
    }

    //action with user presses on "done" button
    private void OnCompleted(object sender, EventArgs e)
    {
        entry.Unfocus();
    }
}