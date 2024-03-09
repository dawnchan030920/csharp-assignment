using Fluxor;

namespace Front.Store.PrimeUseCase;

public static class PrimeReducers
{
  [ReducerMethod]
  public static PrimeState ReduceMinChangeAction(PrimeState state, MinChangeAction action) => action.Value <= state.Max ? (state with { Min = action.Value }) : state;

  [ReducerMethod]
  public static PrimeState ReduceMaxChangeAction(PrimeState state, MaxChangeAction action) => action.Value >= state.Min ? (state with { Max = action.Value }) : state;
}