k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidLight.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoValidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidFluent.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoValidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\ValidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoValidModel.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoValidModel.csv

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidLight.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoInvalidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidFluent.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoInvalidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveTwo\InvalidTestParametersPrimitiveTwo.js
rm .\Results\ResultParametersPrimitiveTwoInvalidModel.csv
mv result.csv .\Results\ResultParametersPrimitiveTwoInvalidModel.csv

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidLight.csv
mv result.csv .\Results\ResultParametersPrimitiveAllValidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidFluent.csv
mv result.csv .\Results\ResultParametersPrimitiveAllValidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\ValidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllValidModel.csv
mv result.csv .\Results\ResultParametersPrimitiveAllValidModel.csv

k6 run -e VALIDATION_NAME=light .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidLight.csv
mv result.csv .\Results\ResultParametersPrimitiveAllInvalidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidFluent.csv
mv result.csv .\Results\ResultParametersPrimitiveAllInvalidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersPrimitiveAll\InvalidTestParametersPrimitiveAll.js
rm .\Results\ResultParametersPrimitiveAllInvalidModel.csv
mv result.csv .\Results\ResultParametersPrimitiveAllInvalidModel.csv

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidLight.csv
mv result.csv .\Results\ResultParametersComplexTwoValidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidFluent.csv
mv result.csv .\Results\ResultParametersComplexTwoValidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\ValidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoValidModel.csv
mv result.csv .\Results\ResultParametersComplexTwoValidModel.csv

k6 run -e VALIDATION_NAME=light .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidLight.csv
mv result.csv .\Results\ResultParametersComplexTwoInvalidLight.csv

k6 run -e VALIDATION_NAME=fluent .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidFluent.csv
mv result.csv .\Results\ResultParametersComplexTwoInvalidFluent.csv

k6 run -e VALIDATION_NAME=model .\ParametersComplexTwo\InvalidTestParametersComplexTwo.js
rm .\Results\ResultParametersComplexTwoInvalidModel.csv
mv result.csv .\Results\ResultParametersComplexTwoInvalidModel.csv

k6 run -e VALIDATION_NAME=light .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidLight.csv
mv result.csv .\Results\ResultCollectionFlatValidLight.csv

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidFluent.csv
mv result.csv .\Results\ResultCollectionFlatValidFluent.csv

k6 run -e VALIDATION_NAME=model .\CollectionFlat\ValidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatValidModel.csv
mv result.csv .\Results\ResultCollectionFlatValidModel.csv

k6 run -e VALIDATION_NAME=light .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidLight.csv
mv result.csv .\Results\ResultCollectionFlatInvalidLight.csv

k6 run -e VALIDATION_NAME=fluent .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidFluent.csv
mv result.csv .\Results\ResultCollectionFlatInvalidFluent.csv

k6 run -e VALIDATION_NAME=model .\CollectionFlat\InvalidTestCollectionFlat.js
rm .\Results\ResultCollectionFlatInvalidModel.csv
mv result.csv .\Results\ResultCollectionFlatInvalidModel.csv

k6 run -e VALIDATION_NAME=light .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidLight.csv
mv result.csv .\Results\ResultCollectionComplexValidLight.csv

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidFluent.csv
mv result.csv .\Results\ResultCollectionComplexValidFluent.csv

k6 run -e VALIDATION_NAME=model .\CollectionComplex\ValidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexValidModel.csv
mv result.csv .\Results\ResultCollectionComplexValidModel.csv

k6 run -e VALIDATION_NAME=light .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidLight.csv
mv result.csv .\Results\ResultCollectionComplexInvalidLight.csv

k6 run -e VALIDATION_NAME=fluent .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidFluent.csv
mv result.csv .\Results\ResultCollectionComplexInvalidFluent.csv

k6 run -e VALIDATION_NAME=model .\CollectionComplex\InvalidTestCollectionComplex.js
rm .\Results\ResultCollectionComplexInvalidModel.csv
mv result.csv .\Results\ResultCollectionComplexInvalidModel.csv

echo done