/// <summary>
/// Interface responsável por definir o gerenciamento do gameplayer.
/// </summary>
public interface IGameplayer
{
    /// <summary>
    /// Método responsável por adicionar pontos ao jogador atrás de injecao de dependencia.
    /// </summary>
    /// <param name="score"></param>
    void AddPoints(int score);

    /// <summary>
    /// Método que finaliza a partida.
    /// </summary>
    void GameOver();
}