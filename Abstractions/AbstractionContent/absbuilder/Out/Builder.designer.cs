 

using System;

	namespace AbstractionBuilder {
	partial class Builder {
        public void Build()
        {
			CleanUp();
            Tuple<string, string>[] generatorFiles = null;
			        generatorFiles = ExecuteAssemblyGenerator("ObjectRelational", "ABS", "MVCEditView_v1_0");
	        WriteGeneratorFiles(generatorFiles, "ObjectRelational", "ABS");
			        generatorFiles = ExecuteAssemblyGenerator("ObjectRelational", "ABS", "MVCControllers_v1_0");
	        WriteGeneratorFiles(generatorFiles, "ObjectRelational", "ABS");
		        }
		
		private void CleanUp()
		{
		            CleanUpAbstractionOutput("ObjectRelational");
						}
	}
}
		