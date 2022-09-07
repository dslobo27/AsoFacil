namespace AsoFacil.Application.Extensions
{
    public static class MessagesApi
    {
        public static string Sucess(string entity, string action, EntityGender? entityGender = EntityGender.Masculino)
        {
            var actionMessage = GetAction(action, entityGender.Value);
            return $"{entity} {actionMessage} com sucesso!";
        }

        public static string Error(string entity, string action, EntityGender? entityGender = EntityGender.Masculino)
        {
            var actionMessage = GetAction(action, entityGender.Value);
            return $"{entity} não foi {actionMessage}. Tente novamente!";
        }

        public static string Exception(string entity, string action)
        {
            var actionMessage = GetActionOnException(action);
            return $"Ocorreu um erro ao {actionMessage} {entity}!";
        }

        private static string GetArticle(EntityGender entityGender)
        {
            return entityGender.Equals(EntityGender.Masculino) ? "o" : "a";
        }

        private static string GetAction(string action, EntityGender entityGender)
        {
            var actionArr = action.Split("_");
            switch (actionArr[0])
            {
                case "PUT":
                    return string.Format("{0}{1}", "alterad", GetArticle(entityGender));

                case "POST":
                    return string.Format("{0}{1}", "criad", GetArticle(entityGender));

                case "DELETE":
                    return string.Format("{0}{1}", "excluid", GetArticle(entityGender));
            }
            return null;
        }

        private static string GetActionOnException(string action)
        {
            var actionArr = action.Split("_");
            switch (actionArr[0])
            {
                case "PUT":
                    return "alterar";

                case "POST":
                    return "criar";

                case "DELETE":
                    return "excluir";
            }
            return "obter";
        }
    }

    public enum EntityGender
    {
        Masculino,
        Feminino
    }
}