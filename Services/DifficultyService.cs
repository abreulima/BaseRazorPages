using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Models;

namespace Services
{
    public class DifficultyService
    {

        private readonly DifficulltyRepository _difficulltyRepository;

        public DifficultyService(DifficulltyRepository difficulltyRepository)
        { 
            _difficulltyRepository = difficulltyRepository;
        }

        public List<Difficulty> GetAllDifficulties()
        {
            return _difficulltyRepository.GetDifficulties();
        }

        public void  AddDifficulty(Difficulty difficulty)
        {
            _difficulltyRepository.AddDifficult(difficulty);
        }

    }
}
