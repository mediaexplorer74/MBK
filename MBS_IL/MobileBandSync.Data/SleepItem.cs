namespace MobileBandSync.Data;

public class SleepItem
{
	public string UniqueId => SleepId.ToString("B");

	public string Title { get; private set; }

	public string Subtitle { get; private set; }

	public string Description { get; private set; }

	public string ImagePath { get; private set; }

	public string Content { get; private set; }

	public int SleepId { get; set; }

	public int SleepActivityId { get; set; }

	public int SecFromStart { get; set; }

	public byte SegmentType { get; set; }

	public byte SleepType { get; set; }

	public byte Heartrate { get; set; }

	public SleepItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content)
	{
		Title = title;
		Subtitle = subtitle;
		Description = description;
		ImagePath = imagePath;
		Content = content;
	}

	public SleepItem()
	{
	}

	public override string ToString()
	{
		return Title;
	}
}
