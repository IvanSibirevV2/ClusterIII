using System;
using System.Collections.Generic;


namespace FuzzyLibrary {
  /// <summary>
  /// Linguistic variable
  /// </summary>
  public class FuzzyVariable : NamedVariableImpl {
    double _min = 0.0, _max = 10.0;
    List<FuzzyTerm> _terms = new List<FuzzyTerm>();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name of the variable</param>
    /// <param name="min">Minimum value</param>
    /// <param name="max">Maximum value</param>
    public FuzzyVariable(string name, double min, double max)
      : base(name) {
      if (min > max) {
        throw new ArgumentException("Maximum value must be greater than minimum one.");
      }

      _min = min;
      _max = max;
    }

    /// <summary>
    /// Terms
    /// </summary>
    public List<FuzzyTerm> Terms {
      get { return _terms; }
    }

    /// <summary>
    /// Named values
    /// </summary>
    public override List<INamedValue> Values {
      get {
        List<INamedValue> result = new List<INamedValue>();
        foreach (FuzzyTerm term in _terms) {
          result.Add(term);
        }
        return result;
      }
    }

    /// <summary>
    /// Get membership function (term) by name
    /// </summary>
    /// <param name="name">Term name</param>
    /// <returns></returns>
    public FuzzyTerm GetTermByName(string name) {
      foreach (FuzzyTerm term in _terms) {
        if (term.Name == name) {
          return term;
        }
      }

      throw new KeyNotFoundException();
    }

    public FuzzyTerm GetTermByMF(IMembershipFunction mf) {
      foreach (FuzzyTerm term in _terms) {
        if (term.MembershipFunction == mf) {
          return term;
        }
      }

      return null;
    }

    /// <summary>
    /// Maximum value of the variable
    /// </summary>
    public double Max {
      get { return _max; }
      set { _max = value; }
    }

    /// <summary>
    /// Minimum value of the variable
    /// </summary>
    public double Min {
      get { return _min; }
      set { _min = value; }
    }

    public bool ValidateInputValue(double var) {
      return var >= Min && var <= Max;
    }

    public double GetCorrectValue(double var) {
      if (var < Min)
        var = Min;
      else if (var > Max)
        var = Max;
      return var;
    }
  }
}
