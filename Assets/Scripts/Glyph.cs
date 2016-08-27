public class Glyph 
{
    public Glyph(char letter, int id)
    {
        Letter = letter;
        VisualId = id;
    }

    public char Letter { get; private set; }
    public int VisualId { get; private set; }

}