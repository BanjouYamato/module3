public interface IState
{
    void EnterState(Player player);
    void ExitState(Player player);
    void UpdateState(Player player);
}
