﻿using System;
using System.Collections.Generic;
using System.Linq;
using LoadingApp.Data;
using LoadingApp.MathLib.Logic.Interfaces;
using LoadingApp.MathLib.Logic.MathModelingProviders;
using LoadingApp.MathLib.Logic.Models;

namespace LoadingApp.MathLib.Logic.ResultsProvider
{
    public class ModelingResultsProvider : IModelingResultsProvider
    {
        private readonly LoadingProgramProvider _loadingProgramProvider;
        private readonly PlacingPlanProvider _placingPlanProvider;

        public ModelingResultsProvider()
        {
            _loadingProgramProvider = new LoadingProgramProvider();
            _placingPlanProvider = new PlacingPlanProvider();
        }

        public ModelingResult GetLoadingAndPlacingPrograms(List<Box> boxesForPlacing, Container container)
        {
            if (boxesForPlacing == null)
            {
                throw new ArgumentNullException(nameof(boxesForPlacing));
            }

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var boxesToPlaceNumber = boxesForPlacing.Sum(box => box.OrderQuantity);

            var loadingProgram = _loadingProgramProvider.GetLoadProgram(boxesForPlacing, container);
            var placingPlan = _placingPlanProvider.GetPlacingPlan(loadingProgram, container);

            var boxesAfterPlacingNumber = placingPlan.SelectMany(box => box).Count();
            var executionPercent = (double) boxesAfterPlacingNumber / boxesToPlaceNumber * 100;

            return new ModelingResult
            {
                Container = container,
                LoadingProgram = loadingProgram,
                PlacingPlan = placingPlan,
                ExecutionPercent = executionPercent
            };
        }
    }
}
