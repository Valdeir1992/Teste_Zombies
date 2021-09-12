/// <summary>
/// Interface responsável por implmentar o padrao adapter para o save.
/// </summary>
internal interface ISaveController
{
    void Load();
    void Save(int save); 
    Save CurrentSave
    {
        get;
    }
}