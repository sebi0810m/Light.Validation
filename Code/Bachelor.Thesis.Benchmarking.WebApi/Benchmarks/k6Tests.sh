k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\ValidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\ValidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\ValidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\InvalidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\InvalidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\InvalidParametersPrimitiveTwo.js
mv result.json.\Results\ResultParametersPrimitiveTwoInvalidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\ValidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\ValidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\ValidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\InvalidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\InvalidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\InvalidParametersPrimitiveAll.js
mv result.json.\Results\ResultParametersPrimitiveAllInvalidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\ValidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\ValidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\ValidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\InvalidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\InvalidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\InvalidParametersComplexTwo.js
mv result.json.\Results\ResultParametersComplexTwoInvalidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionFlat\ValidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatValidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\ValidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatValidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionFlat\ValidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatValidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionFlat\InvalidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\InvalidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionFlat\InvalidCollectionFlat.js
mv result.json.\Results\ResultCollectionFlatInvalidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionComplex\ValidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexValidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\ValidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexValidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionComplex\ValidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexValidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionComplex\InvalidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\InvalidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionComplex\InvalidCollectionComplex.js
mv result.json.\Results\ResultCollectionComplexInvalidModel.json

echo done
