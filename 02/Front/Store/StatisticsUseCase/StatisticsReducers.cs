using Fluxor;

namespace Front.Store.StatisticsUseCase;

public static class StatisticsReducers
{
  [ReducerMethod]
  public static StatisticsState ReduceInputChangeAction(StatisticsState state, InputChangeAction action) => state with { Input = action.Input };

  [ReducerMethod]
  public static StatisticsState ReduceNewItemAction(StatisticsState state, NewItemAction action) => state with { Ints = [.. state.Ints, action.NewItem], Input = default };

  [ReducerMethod]
  public static StatisticsState ReduceDeleteItemAction(StatisticsState state, DeleteItemAction action) => state with { Ints = [.. state.Ints[..action.Index], .. state.Ints[(action.Index + 1)..]], Current = state.Ints.Count == action.Index + 1 ? action.Index - 1 : action.Index };

  [ReducerMethod]
  public static StatisticsState ReduceCurrentChangeAction(StatisticsState state, CurrentChangeAction action) => state with { Current = action.Current };
}