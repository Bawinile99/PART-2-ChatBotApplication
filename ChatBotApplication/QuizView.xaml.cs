using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POEChatBotApplication.Views
{
    public partial class QuizView : UserControl
    {
        private List<Question> Questions = new();
        private int currentQuestionIndex = 0;
        private int score = 0;

        public QuizView()
        {
            InitializeComponent();
            LoadQuestions();
            DisplayCurrentQuestion();
        }

        private void LoadQuestions()
        {
            Questions = new List<Question>
    {
        new Question("🔴 What is phishing?",
            new[] { "Fishing in a lake", "A cyberattack to steal info", "A type of computer", "A coding language" }, 1),

        new Question("🔴 What should you do with suspicious emails?",
            new[] { "Open all attachments", "Click all links", "Delete immediately", "Forward to friends" }, 2),

        new Question("🔴 What makes a strong password?",
            new[] { "Using 'password'", "Your pet's name", "Random letters+numbers", "Your birthday" }, 2),

        new Question("🔴 What does HTTPS mean?",
            new[] { "Hyper Text Transfer Protocol", "Hacker Test Transfer Protocol", "Secure website connection", "High Tech Transfer System" }, 2),

        new Question("🔴 What is malware?",
            new[] { "A type of fish", "Good computer software", "Malicious software", "A computer brand" }, 2),

        new Question("🔴 Why use antivirus?",
            new[] { "Makes computer faster", "Protects against viruses", "Changes screen color", "Creates passwords" }, 1),

        new Question("🔴 What is 2FA?",
            new[] { "Two Friends Authentication", "Two-Factor Authentication", "Two File Access", "Too Fast Authentication" }, 1),

        new Question("🔴 What should you share online?",
            new[] { "Your passwords", "Personal information", "Only what's necessary", "Your home address" }, 2)
    };
        }


        private void DisplayCurrentQuestion()
        {
            if (currentQuestionIndex >= Questions.Count)
            {
                ShowFinalFeedback();
                return;
            }

            Question current = Questions[currentQuestionIndex];
            QuestionText.Text = current.Text;
            OptionsPanel.Items.Clear();

            for (int i = 0; i < current.Options.Length; i++)
            {
                var radio = new RadioButton
                {
                    Content = current.Options[i],
                    Tag = i,
                    GroupName = "QuizOptions",
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red),
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                OptionsPanel.Items.Add(radio);
            }
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            var selectedOption = OptionsPanel.Items.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            if (selectedOption == null)
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            int selectedIndex = (int)selectedOption.Tag;
            if (selectedIndex == Questions[currentQuestionIndex].CorrectOption)
            {
                score++;
                FeedbackText.Text = "✅ Correct! Great job!";
                FeedbackText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
            }
            else
            {
                FeedbackText.Text = "❌ Oops! Try the next one!";
                FeedbackText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            }

            currentQuestionIndex++;
            ScoreText.Text = $"📊 Score: {score}";
            ScoreProgressBar.Value = score;

            if (currentQuestionIndex < Questions.Count)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                ShowFinalFeedback();
            }
        }

        private void ShowFinalFeedback()
        {
            QuestionText.Text = "🛡️ Cyber Quiz Complete!";
            OptionsPanel.Items.Clear();
            ScoreText.Text = $"📊 Final Score: {score}/8";
            ScoreProgressBar.Value = score;

            if (score == 8)
                FeedbackText.Text = "💻 Elite Hacker Status! Perfect!";
            else if (score > 6)
                FeedbackText.Text = "🔐 Security Expert! Great job!";
            else if (score > 4)
                FeedbackText.Text = "⚠️ Good Awareness! Keep learning!";
            else
                FeedbackText.Text = "🛑 Newbie Alert! Study more!";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize with red text
            QuestionText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            ScoreText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            FeedbackText.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
        }

        public class Question
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectOption { get; set; }

            public Question(string text, string[] options, int correctOption)
            {
                Text = text;
                Options = options;
                CorrectOption = correctOption;
            }
        }
    }
}