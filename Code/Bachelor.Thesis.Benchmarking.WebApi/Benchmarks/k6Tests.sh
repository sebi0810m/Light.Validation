k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidLight.json
mv result.json .\Results\ResultParametersPrimitiveTwoValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidFluent.json
mv result.json .\Results\ResultParametersPrimitiveTwoValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidModel.json
mv result.json .\Results\ResultParametersPrimitiveTwoValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidLight.json
mv result.json .\Results\ResultParametersPrimitiveTwoInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidFluent.json
mv result.json .\Results\ResultParametersPrimitiveTwoInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidModel.json
mv result.json .\Results\ResultParametersPrimitiveTwoInvalidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidLight.json
mv result.json .\Results\ResultParametersPrimitiveAllValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidFluent.json
mv result.json .\Results\ResultParametersPrimitiveAllValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidModel.json
mv result.json .\Results\ResultParametersPrimitiveAllValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidLight.json
mv result.json .\Results\ResultParametersPrimitiveAllInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidFluent.json
mv result.json .\Results\ResultParametersPrimitiveAllInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidModel.json
mv result.json .\Results\ResultParametersPrimitiveAllInvalidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidLight.json
mv result.json .\Results\ResultParametersComplexTwoValidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidFluent.json
mv result.json .\Results\ResultParametersComplexTwoValidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidModel.json
mv result.json .\Results\ResultParametersComplexTwoValidModel.json

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidLight.json
mv result.json .\Results\ResultParametersComplexTwoInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidFluent.json
mv result.json .\Results\ResultParametersComplexTwoInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidModel.json
mv result.json .\Results\ResultParametersComplexTwoInvalidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidLight.json
mv result.json .\Results\ResultCollectionFlatValidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidFluent.json
mv result.json .\Results\ResultCollectionFlatValidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidModel.json
mv result.json .\Results\ResultCollectionFlatValidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidLight.json
mv result.json .\Results\ResultCollectionFlatInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidFluent.json
mv result.json .\Results\ResultCollectionFlatInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidModel.json
mv result.json .\Results\ResultCollectionFlatInvalidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidLight.json
mv result.json .\Results\ResultCollectionComplexValidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidFluent.json
mv result.json .\Results\ResultCollectionComplexValidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidModel.json
mv result.json .\Results\ResultCollectionComplexValidModel.json

k6 run -e VALIDATION_NAME=light .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidLight.json
mv result.json .\Results\ResultCollectionComplexInvalidLight.json

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidFluent.json
mv result.json .\Results\ResultCollectionComplexInvalidFluent.json

k6 run -e VALIDATION_NAME=model .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidModel.json
mv result.json .\Results\ResultCollectionComplexInvalidModel.json

echo done