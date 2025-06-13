# Interface overview

This page summarises the public interfaces in the Altinn App libraries. The descriptions are based on the inline XML comments but also grouped and paraphrased to provide a high level understanding of the available extension points.

## Application configuration
- **IAppModel** – creates instances of the app's data model
- **IAppMetadata** / **IApplication** – access to application metadata
- **IApplicationClient** – fetches application metadata from platform
- **IAppResources** – provides access to embedded resources like texts and layouts
- **IApplicationLanguage** – lists languages the app supports
- **IAppOptionsProvider**, **IAppOptionsFileHandler**, **IAppOptionsService** – serve option lists used in forms
- **IFrontendFeatures** – reports backend capabilities to the frontend
- **IPageOrder** – defines page navigation in stateful apps
- **ILanguageCodeStandard** – helper for ISO 639-1 codes
- **IText** and **ITranslationService** – text resource lookups and translations

## Process engine and tasks
- **IProcessEngine**, **IProcessNavigator** and **IProcessReader** – read and execute the BPMN model
- **IProcessTask** plus **IProcessTaskInitializer**, **IProcessTaskCleaner**, **IProcessTaskDataLocker**, **IProcessTaskFinalizer** – customise task behaviour
- **IProcessTaskStart**, **IProcessTaskEnd**, **IProcessTaskAbandon** – hooks for task events
- **IServiceTask** – implement custom service tasks
- **IStartTaskEventHandler**, **IEndTaskEventHandler**, **IAbandonTaskEventHandler** – event handlers triggered by the engine
- **IProcessExclusiveGateway** – custom decision logic for gateways
- **IProcessEventDispatcher** and **IProcessEventHandlerDelegator** – dispatch and route process events
- **IProcessEnd** – logic to run when the overall process ends

## Data handling and validation
- **IData**, **IDataClient**, **IDataService** – read and write instance data
- **IDataProcessor** and **IDataWriteProcessor** – modify data during processing or write operations
- **IDataElementValidator** and **IFormDataValidator** – validate individual data elements
- **IFileAnalyser**, **IFileAnalyserFactory**, **IFileAnalysisService** – inspect uploaded files
- **IFileValidator** and **IFileValidatorFactory** – validate files
- **IValidator**, **IValidatorFactory**, **IValidationService** – general validation framework
- **IInstanceValidator**, **IInstantiationValidator** – validation during instantiation and process
- **IInstanceDataAccessor**, **IInstanceDataMutator** – access or modify other data elements in an instance
- **IDataListProvider**, **IDataListsService**, **IInstanceDataListProvider**, **IInstanceAppOptionsProvider** – supply data lists and options scoped to an instance

## Authentication and authorization
- **IAuthentication** and **IAuthenticationClient** – handle user and system authentication
- **IAuthenticationContext** – provides the current authentication state
- **IAuthorization**, **IAuthorizationClient**, **IAuthorizationService** – check access rights
- **IUserTokenProvider** – create JSON Web Tokens for the current user
- **IUserActionAuthorizer** and **IUserActionAuthorizerProvider** – custom authorization for user actions
- **IProcessEngineAuthorizer** – authorizes process events

## External registries and platform services
- **IAltinnPartyClient**, **IPersonClient**, **IOrganizationClient**, **IER**, **IDSF**, **IRegister** – fetch information about persons and organisations
- **IProfileClient** and **IProfile** – access user profile data
- **IAppEvents**, **ITaskEvents**, **IInstanceEventClient** – handle instance and task events
- **IEvents**, **IEventsClient**, **IEventsSubscription** – interact with the platform event system
- **IPersonLookup**, **IPersonRetriever** – lookup helpers used by the data services

## Notifications and messaging
- **IEmailNotificationClient** and **ISmsNotificationClient** – send notifications via Altinn
- **ICorrespondenceClient** with related builder interfaces – create and send correspondence messages
- **IEFormidlingService**, **IEFormidlingReceivers**, **IEFormidlingMetadata** – integrate with the eFormidling service
- **IEventHandler**, **IEventHandlerResolver**, **IEventSecretCodeProvider** – receive external events and handle secret codes

## Documents and signing
- **IPdfService** and **IPdfGeneratorClient** – generate and store PDFs
- **IPdfFormatter** – customise PDF formatting
- **ISignClient** and **ISigneeProvider** – initiate signing requests and resolve signees

## Payment
- **IPaymentProcessor** and **IOrderDetailsCalculator** – implement payment processing

## Miscellaneous
- **IUserAction** – implement custom user actions in processes
- **IPrefill** – populate data models from register information
- **IProcessClient** and **IProcess** – read process definitions
- **IEventHandlerResolver** – resolve handlers for event types
- **IMaskinportenClient**, **IMaskinportenTokenProvider**, **IX509CertificateProvider** – handle Maskinporten authentication and certificates
- **IValidateQueryParamPrefill** – validate query parameters used for prefill
- **ILayoutEvaluatorStateInitializer** – initialise the layout expression engine

This list gives an overview of the extensibility points available to Altinn app developers. Interfaces marked with the `ImplementableByApps` attribute are intended to be implemented in the app itself to plug in custom logic.
