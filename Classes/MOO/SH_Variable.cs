﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMetalCSharp.Core;
using JMetalCSharp.Encoding.SolutionType;
using JMetalCSharp.Encoding.Variable; 

namespace SimpleShapeGrammar.Classes
{
    public class SH_Variable : Variable
    {
        // -- properties -- 

        /// <summary>
        /// Problem using the type
        /// </summary>
        private SH_NSGAIIProblem problem;
        /// <summary>
        /// Stores a list of SH_Rule class which forms the basis of the genome.
        /// </summary>
        public List<SH_Rule> List { get; set; }
        /// <summary>
        /// Stores the length of the list
        /// </summary>
        public int Size { get; set; }

        // -- constructors -- 
        public SH_Variable()
        {
            List = null;
            Size = 0;
            problem = null; 
        }
        public SH_Variable(List<SH_Rule> ruleList)
        {
            Size = ruleList.Count;
            List = ruleList; 
        }
        public SH_Variable(SH_NSGAIIProblem _problem)
        {
            problem = _problem;
            List = MOO_Utility.NewGenome(problem.availableRules, problem.weights, problem.MyComponent.MyRand);
        }

        private SH_Variable(SH_Variable shapeGrammarVariable)
        {
            List = shapeGrammarVariable.List;
            problem = shapeGrammarVariable.problem;
        }

        

        // -- methods --
        public override Variable DeepCopy()
        {
            return new SH_Variable(this);
        }
    }
}