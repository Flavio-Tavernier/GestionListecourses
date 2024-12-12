using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionListeCourses.modele
{
    internal class TypeIngredient
    {
        private int idType;
        private string nomType;

        public TypeIngredient(int idType, string nomType)
        {
            this.idType = idType;
            this.nomType = nomType;
        }


        public int GetIdType()
        {
            return idType;
        }
        public void SetIdType(int idType)
        {
            this.idType = idType;
        }

        public string GetNomType()
        {
            return nomType;
        }
        public void SetNomType(string nomType)
        {
            this.nomType = nomType;
        }

    }
}
