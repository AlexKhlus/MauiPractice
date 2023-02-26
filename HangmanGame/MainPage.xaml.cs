namespace HangmanGame;
public partial class MainPage : ContentPage
{
	private readonly List<string> _words;
	private readonly int _maxAttemptsNumber;

	private string _guessedLetters;
	private string _answer;
	private string _spotlight;
	private string _message;
	private string _status;
	private string _currentImage;

	private int _attemptsCount;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;

		_words = new () {
			"python", "javascript", "maui", "csharp",
			"mongodb", "sql", "xaml", "word",
			"excel", "powerpoint", "code", "hotreload",
			"snippets"
		};
		_guessedLetters = string.Empty;
		_attemptsCount = default;
		_maxAttemptsNumber = 6;

		(Letters = new ()).AddRange("abcdefghijklmnopqrstuvwxyz");
		CurrentImage = "img0.jpg";
		OnPropertyChanged(nameof(Letters));

		UpdateStatus();
		PickWord();
		DefineWord();
	}

	public string Spotlight
	{
		get => _spotlight;
		set
		{
			_spotlight = value;
			OnPropertyChanged();
		}
	}

	public string Message
	{
		get => _message;
		set
		{
			_message = value;
			OnPropertyChanged();
		}
	}

	public string Status
	{
		get => _status;
		set
		{
			_status = value;
			OnPropertyChanged();
		}
	}

	public string CurrentImage
	{
		get => _currentImage;
		set
		{
			_currentImage = value;
			OnPropertyChanged();
		}
	}

	public List<char> Letters { get; private set; }

	private void PickWord()
		=> _answer = _words[new Random(DateTime.UtcNow.Millisecond).Next(default, _words.Count)];

	private void DefineWord()
		=> Spotlight = string.Join(
			separator:' ',
			values: _answer.Select(letter => _guessedLetters.IndexOf(letter) >= 0 ? letter : '_')
		);

	private void HandleGuess(string letter)
	{
		if(_guessedLetters.Contains(letter) is false)
			_guessedLetters = _guessedLetters.Insert(_guessedLetters.Length, letter);

		if(_answer.Contains(letter))
			DefineWord();
		else if(_answer.Contains(letter) is false)
		{
			_attemptsCount++;
			CurrentImage = $"img{_attemptsCount}.jpg";
		}

		UpdateStatus();
		CheckEndGame();
	}

	private void UpdateStatus()
		=> Status = $"Errors: {_attemptsCount} of {_maxAttemptsNumber}";

	private void CheckEndGame()
	{
		if(Spotlight.Replace(" ", string.Empty).Equals(_answer))
		{
			Message = "You win!";
			StopGame();
		}

		if(_attemptsCount >= _maxAttemptsNumber)
		{
			Message = "You lost!";
			StopGame();
		}
	}

	private void ChangeKeyboardState(bool isEnabled)
	{
		foreach(var element in KeyboardFlexLayout.Children)
			if(element is Button button)
				button.IsEnabled = isEnabled;
	}

	private void StopGame()
		=> ChangeKeyboardState(isEnabled: false);

	private void OnLetterButtonClicked(object sender, EventArgs e)
	{
		if(sender is not Button button)
			return;

		var letter = button.Text;
		button.IsEnabled = false;
		HandleGuess(letter);
	}

	private void OnResetButtonClicked(object sender, EventArgs e)
	{
		_attemptsCount = default;
		_guessedLetters = string.Empty;
		CurrentImage = "img0.jpg";
		Message = string.Empty;

		UpdateStatus();
		PickWord();
		DefineWord();

		ChangeKeyboardState(isEnabled: true);
	}
}
