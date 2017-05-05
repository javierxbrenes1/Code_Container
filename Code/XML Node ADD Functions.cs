  private void AgregarNodos(ref XmlDocument pvcDocumento, string pvcNombre, bool pvbEsPadre,
                                  string pvcNombreNodoPadre = "",  string pvcContenido = "") 
        {
            XmlNode vloNodoPadre;
            XmlNode vloNodoNuevo;
            XmlNodeList vloListaNodosAux;
            try
            {
                //Creo el nuevo nodo
                vloNodoNuevo = pvcDocumento.CreateElement(pvcNombre);
                //Verifico si es padre o si debe llevar contenido
                if (!pvbEsPadre)
                {
                    if (!string.IsNullOrEmpty(pvcContenido))
                    {
                        vloNodoNuevo.AppendChild(pvcDocumento.CreateTextNode(pvcContenido));
                    }
                }
                //Verifico si trae padre, en caso de no traerlo se agrega al documento
                if (string.IsNullOrEmpty(pvcNombreNodoPadre))
                {
                    //Se agrega el nuevo nodo al documento directamente
                    pvcDocumento.AppendChild(vloNodoNuevo);
                }
                else
                { 
                    //Se obtiene el nodo padre y se agrega a este se obtiene el primero de la lista
                    vloListaNodosAux = pvcDocumento.GetElementsByTagName(pvcNombreNodoPadre);
                    //Obtiene el ultimo nodo de la lista
                    vloNodoPadre = vloListaNodosAux[vloListaNodosAux.Count - 1];
                    //Se agrega 
                    vloNodoPadre.AppendChild(vloNodoNuevo);
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void AgregarNodos(ref XmlDocument pvcDocumento, string[] pvcNombre, string pvcNombreNodoPadre, string[] pvcContenido)
        {
            XmlNode vloNodoPadre;
            XmlNode vloNodoNuevo;
            XmlNodeList vloListaNodosAux;
            try
            {
                //Se obtiene el nodo padre y se agrega a este se obtiene el primero de la lista
                vloListaNodosAux = pvcDocumento.GetElementsByTagName(pvcNombreNodoPadre);
                vloNodoPadre = vloListaNodosAux[vloListaNodosAux.Count - 1];
                //Si la cantidad de nodos es igual a la cantidad de contenido 
                if (pvcNombre.Length == pvcContenido.Length)
                {
                    for (int vlnI = 0; vlnI < pvcNombre.Length; vlnI++)
                    {
                        //Creo el nuevo nodo
                        vloNodoNuevo = pvcDocumento.CreateElement(pvcNombre[vlnI]);
                        //Verifico si es padre o si debe llevar contenido
                        if (!string.IsNullOrEmpty(pvcContenido[vlnI]))
                        {
                            vloNodoNuevo.AppendChild(pvcDocumento.CreateTextNode(pvcContenido[vlnI]));
                        }
                        //Se agrega 
                        vloNodoPadre.AppendChild(vloNodoNuevo);
                     }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }