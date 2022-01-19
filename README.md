# Genexus Platform SDK Samples

This repository contains the same samples that are distributed with Genexus' platform SDK but with key updates which enhance developer experience such as updated `csproj` files, cleaner code and an entire wiki dedicated entirely to making the process of coding your own Genexus extension as easy as it can possibly be.

## Getting started

1. Install Genexus and the Genexus Platform SDK.

> To work on top of a full fledged version of Genexus you're going to have to reach out to them for a license, check out their licensing plans [here](https://www.genexus.com/en/products/genexus/plans-prices-uruguay). If you think you can work with a trial version of Genexus, which is entirely possible for certain simple use cases, request your download link by submitting [this form](https://www.genexus.com/en/products/genexus/try-genexus).

> To get the latest version of the Platform SDK go to the [Genexus Download Center](https://www.genexus.com/en/developers/downloadcenter?data=;;) and look for an entry in their list that says something along the lines of `Genexus 17 Upgrade #7` and click on it. Always select the one that has the highest Upgrade number. By now you should see around six items to download, one of which is the Platform SDK for this version of GX. Download the executable and run it.

2. Clone this repo to the directory of your choice.

```cmd
git clone https://github.com/GxReqOrt/Samples.git
cd Samples
```

3. Run the `bat` script found within the repo (`gx-extensions.bat`) from within a `Developer Command Prompt for VS` **as an administrator** to open up Visual Studio with all the necessary `env` variables loaded.

> The necessary variables to be able to work with this repo are two: `GX_PROGRAM_DIR` which is the location of the IDE's exe file and `GX_SDK_DIR` which is the location of the SDK. Both are automatically set before opening Visual Studio when using the `gx-extensions.bat` script.

> The script **MUST** be run as an **administrator** because, if you look closely, when you open Genexus IDE manually it requests administrator access to your system resources - we want the IDE to have this level of access to system resources when it is opened by Visual Studio for debugging purposes.

## Repository structure

This repository has a total of 9 example projects which showcase different aspects of Genexus extensions, their capabilities and how to build them.

It is organized as a single VS solution with 9 independent projects within it. All of these can be selected as startup project and debugged independently in order for you to learn how things go down under the hood.

* `Community` - **Beginner friendly** - Adds a menu item to Genexus called Community with 6 actions to choose from, ideal to take as a starting point if you need to add a menu item yourself or to do quick tests with the SDK since your code is a click away. [More info on menu items](https://wiki.genexus.com/commwiki/servlet/wiki?27638,Menu+SDK+Example+Extension#!).

> Remember you cannot make code run at startup, you always need to find a way for the user to trigger it within the IDE. If all extensions could run code at startup who knows how slow the IDE might get.

* `ConsoleTool` - If you're planning to build a console tool to work with Genexus this is what you should be looking at. It is a simple console application that lists all `Transactions` within a `Knowledge Base`.

* `DailyDilbert` - Shows how to use RSS feeds and XSL transformations to create dynamic HTML content (a daily Dilbert cartoon in this case), which is then displayed in a tool window.

* `GXTasks` - Creates a sample MSBuild task. [More info on MSBuild tasks](https://wiki.genexus.com/commwiki/servlet/wiki?3908,MSBuild+Tasks).

* `Menu` - **Recommended for advanced developers only** - This one registers a new Genexus object AND a new menu item AND associates a text editor the the new Genexus object. Since it does so many things at once it might be confusing for newbies.

* `NewObject` - **Beginner friendly** - This one showcases how Genexus objects are built and how you can associate a plain text editor to them.

* `RTFText` - This one dives a bit deeper into how Genexus objects are built and creates one that holds rich text within itself. It is useful as a starting point when you need to create your very own editor.

* `ToolWindow` - Dives into how to create a tool window.

* `Widgets` - ???

For more go to [this link](https://wiki.genexus.com/commwiki/servlet/wiki?5931,Category%3AGeneXus+Extensions+Documentation,). Here you'll find how you can create objects like transactions and procedures, write to the console (or output window) etc. 

## Persisting your objects to GXServer

> To work with GXServer you must have a paid license to be able to connect the IDE to your own instance of GXServer and to be able to launch your own instance of GXServer as well.

In order for your new Genexus object to be persisted in and rehydrated from GXServer you first need to restructure your project.

> No samples dive very deep into this concept so read carefully.

You should have a solution with at least two packages:

* `BL` (Business Logic) package with all the basic behavior of your Genexus object, this one will have no relationship whatsoever with the IDE's UI and will be in charge of handling GXServer persistence.

* `UI` package which will extend your Genexus object to have a UI representation. If your object requires an editor or you want your extension to also offer menu items you should define those here.

### BL packages

```cs
[assembly: Package(typeof(MyExtension.BL.Package), IsUIPackage = false)]
[assembly: KBObjectsDeclaration(typeof(MyExtension.BL.MyObject))]
[assembly: KBObjectPartsDeclaration(typeof(MyExtension.BL.MyObjectTypePart))]
namespace MyExtension.BL
{
    [Guid("80696a19-c534-40bf-a06f-2bd638f3d7aa")]
    public class Package : AbstractPackage, IGxPackageBL
    {
        public override string Name
        {
            get { return "MyExtension.BL"; }
        }

        public override void Initialize(IGxServiceProvider services)
        {
            base.Initialize(services);

            LoadObjectTypes();
            LoadPartTypes();
        }

        private void LoadObjectTypes()
        {
            AddObjectType<MyObject>();
        }

        private void LoadPartTypes()
        {
            AddPart<MyObjectTypePart>();
        }

        public override void ReadPart(KBObjectPart part, XPathNavigator partData, ImportOptions options, IReferenceResolver resolver, OutputMessages output)
        {
            if (part is MyObjectTypePart)
            {
                var partProps = partData.SelectSingleNode("Properties");
                if (partProps != null)
                {
                    Artech.Common.Properties.KmwProperties.Read(part, partProps.OuterXml, output);
                }

                var myPart = part as MyObjectTypePart;
                var partText = partData.SelectSingleNode("Text");
                if (partText != null)
                {
                    myPart.Source = partText.InnerXml;
                }
                else
                {
                    myPart.Source = string.Empty;
                }
            }
        }
    }
}
```

You may have noticed this `BL` package defines only the reading mechanism but there is also the writing of an object. **Objects are composed by one or many parts** and it is the part that is responsible for its own serialization. For this take a look at the `NewObject` project - `Part.cs` has a region defined for `serialization` which showcases how to achieve this behavior.

### UI Packages

```cs
[assembly: Package(typeof(MyExtension.UI.Package))]
namespace MyExtension.UI
{
    [Guid("b27308bd-8d7a-4b61-b67f-c63892edb0e5")]
    public class Package : AbstractPackageUI
    {
        public static Guid guid = typeof(Package).GUID;

        public override string Name
        {
            get { return "MyObject.UI"; }
        }

        public override void Initialize(IGxServiceProvider services)
        {
            base.Initialize(services);

            LoadCommandTargets();
            LoadEditors();
        }

        private void LoadCommandTargets()
        {
            AddCommandTarget(new CommandManager());
        }

        private void LoadEditors()
        {
            AddEditor<TextEditor>(typeof(MyObjectTypePart).GUID);
        }
    }
}
```

## Custom text editors for your objects (Monaco Editor)

**Pre-requisites**: Install [Nodejs](https://nodejs.org/dist/v16.13.2/node-v16.13.2-x64.msi) on your system.

If you have source code you want to edit within Genexus you should associate your Object with a `SourcePart` and associate a custom editor to it. This custom editor you could base off of [`Monaco Editor by Microsoft`](https://microsoft.github.io/monaco-editor/). It might look familiar to you since it is the same editor that's used by Visual Studio Code.

You will probably want to have syntax highlighting in your editor. You probably already know of a VSCode extension that adds support for whatever language you want to work with. If that's the case, chances are that syntax is defined as a `TextMate` grammar. These are not supported out of the box by Monaco but they're fairly easy to use, just take a look at [this project](https://github.com/bolinfest/monaco-tm) - Monaco with support for the Python Language through TextMate grammars (made available thanks to WebAssembly).

### Getting the editor inside Genexus (automatically)

1. Fork the [monaco-tm](https://github.com/bolinfest/monaco-tm) repository.
2. Clone your fork.

```cmd
git clone https://github.com/<your-user>/monaco-tm
cd monaco-tm
```

3. Build the project.

```cmd
npm i
npm run release
```

4. Zip the newly created `dist` folder.

5. On Github, create a release in your fork and add the zip file you created in the previous step as an asset. (Point of this is to make the built project accessible via a public URL).

6. Modify the `msbuild` script or `csproj` file of your project to download the zip file after building your extension.

```xml
<!-- Add this at the end of your csproj file -->
<Target Name="Download monaco editor and copy to gx" AfterTargets="AfterBuild">
    <DownloadFile SourceUrl="https://github.com/<your-user>/monaco-tm/releases/download/<version-code>/dist.zip" DestinationFolder="$(GX_PROGRAM_DIR)\Monaco\MyExtension" />
    <Unzip SourceFiles="$(GX_PROGRAM_DIR)\Monaco\MyExtension\dist.zip" DestinationFolder="$(GX_PROGRAM_DIR)\Monaco\MyExtension\dist" />
    <Delete Files="$(GX_PROGRAM_DIR)\Monaco\MyExtension\dist.zip" />
</Target>
```

> If you have both a `BL` and a `UI` package this change goes in the `UI` package since the editor is 100% UI.

### Using the editor in C#

```cs
public class TextEditor : AbstractTextEditor, IGxView
{
    public TextEditor()
        : base("./Monaco/MyExtension/dist/index.html")
    {
    }

    public override IGXObjectForScripting GetObjectForScripting() => new BoundHost(this, null);
}
```

> **Pro tip** If you want to modify your editor and have Genexus update in real time you can always consider working with watchers. The command `tsc -w` will keep your `dist` folder updated with the latest version of your code as you edit it for as long as it's running. Anyway, the browser will need to be refreshed on each change: `editor.Browser.Refresh();` does just that. TL;DR: Point your `TextEditor` class to the output of your `tsc -w` command and refresh the browser on each change (consider using menu items for simplicity).

```cs
public class BoundHost : IGXObjectForScripting, IDocumentHost
{
    protected AbstractTextEditor m_editor;
    protected KBObject m_documentObject;

    public BoundHost(AbstractTextEditor editor, KBObject documentObject)
    {
        m_editor = editor;
        m_documentObject = documentObject;
    }

    public void Initialize(AbstractWebEditor editor)
    {
        editor.Text = ((MyObject)m_documentObject).Text;
    }

    public void SetDocumentObject(KBObject documentObject)
    {
        m_documentObject = documentObject;
    }
}
```

> **Pro tip** If you need to debug your editor within Genexus you can always enable devtools in the inner instance of Chrome. Add `editor.Browser.ShowDevTools();` to the `Initialize` method of your `BoundHost` class.

> **Super pro tip** You can debug AND have hot reload (or at least pseudo hot reload) on your editor combining both `Pro Tips` ;)

### Communicating between Monaco (the inner browser) and Genexus IDE

**Genexus >> Inner instance of Chrome** => `editor.Browser.ExecuteJavaScriptAsync(string code)`

**Inner instance of Chrome >> Genexus**

The example editor has a `Text` property. To be able to put a value in it from `JavaScript` all you have to do is define a `SetText` function in the global scope like done here in a script tag.

The reason why it does the assignment within an interval is that at first the reference to the `editor` does not exist, this code attempts to set the text as many times as necessary until it succeeds.

```html
<script type="text/javascript">
  var editor;
  var SetText;

  SetText = function (x) {
    const interval = setInterval(() => {
      if (!editor) {
        return;
      }

      clearInterval(interval);
      editor.setValue(x);
    }, 20);
  }
</script>
```

Someting else you might want to do is to call C# methods from `JavaScript`, which enables use-cases such as a context menu item in monaco to run code defined in your `BoundHost`. These methods which are defined in your `BoundHost` can be called as part of the `window.external` object.

For example, if you have a method called `DoSomething()` defined in your `BoundHost` you can call it like:

```js
window.external.DoSomething();
```
