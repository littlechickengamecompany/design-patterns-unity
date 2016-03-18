/// Little Chicken C# Conventions 2015


/// ## Conventions fundamentals
/// 
/// # FAVOUR READABILITY OVER WRITABILITY
/// This means we write summaries for our public fields and methods, 
/// and make sure our names and algorithms make sense to the reader. 
/// The best programmer writes the simplest code.
/// 
/// # THE BEGINNING OF WISDOM IS TO CALL THINGS BY THEIR PROPER NAME
/// When writing a class/method make sure it only does the thing that 
/// it is named to do. If not, either change the name or change the
/// content.
/// 
/// # MAKE EVERYTHING AS CONSTANT, PRIVATE AND SCOPED AS POSSIBLE
/// By making fields constant, private/protected and declare it only 
/// in the scope that it is needed we reduce the amount of options 
/// when debugging.


/// ## Meta conventions
/// 
/// - Don't make classes longer than 350 lines of code
/// - A filename must match its containing class or other type name
/// - Use namespaces parallel with folder structure
/// - Don't commit warnings
/// - Methods should be named and designed to do only one thing


/// ## Convention inspirations
/// 
/// # http://kotaku.com/5975610/the-exceptional-beauty-of-doom-3s-source-code
/// This article describes good practices performed in the development 
/// of Doom 3.
/// 
/// # http://programmer.97things.oreilly.com/wiki/index.php/Don't_Repeat_Yourself
/// The DRY principle stance for Don't Repeat Yourself. Duplicate code 
/// is harder too understand.


using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Conventions.Demo;
using Conventions.Examples;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Conventions.Examples {

    /// <summary>
    /// This class demo's our ordering, capitalization syntax, good practice 
    /// and bad practice conventions. Summaries are left out for readability, 
    /// but should always be added to every public field/method. States, 
    /// structs, constants, etc. should be ordered as shown in this class, 
    /// grouped by access modifier (public, protected, private).
    /// </summary>
    public class MyClass : AbstractClass {

        public enum State {
            StateOne,
            StateTwo
        }

        public struct MyStruct { }

        public const int MY_CONSTANT = 0;

        public delegate void AlarmEventHandler(object args);

        public int MyProperty { get; private set; }

        public int MySecondProperty {
            get {
                return privateField + privateSecondField;
            }
        }

        public int MyField;
		public AlarmEventHandler AlarmEvent;
		
        protected enum ProtectedState {
            StateOne,
            StateTwo
        }

        protected struct MyProtectedStruct { }

        protected const string MY_PROTECTED_CONSTANT = "Hi";

        protected delegate void ProtectedAlarmEventHandler(object args);

        protected int protectedField;

        private enum PrivateState {
            StateOne,
            StateTwo
        }

        private struct MyPrivateStruct { }

        private const int MY_PRIVATE_CONSTANT = 1337;

        private delegate void PrivateAlarmEventHandler(object args);

        private int privateField;
        private int privateSecondField;

        public MyClass(bool myParameter)
            : base(myParameter) {

        }

        public void MyMethod(int myParameter) {

        }

        protected void MyProtectedMethod(int myParameter) {

        }

        private void MyPrivateMethod(int myParameter) {

        }

        /// <summary>
        /// This method contains good practices in our conventions.
        /// </summary>
        private void GoodPractices(Foo foo) {

            // Proper error handling (classes should always be robust even though they aren't initialized properly)
            if (foo == null) {
                Debug.LogError("Can't perform good practises when foo is null.");
                return;
            }

            // Use lambda for simple iterations
            List<Bar> bars = new List<Bar>();
            bars.ForEach(x => x.Do());
            bars.RemoveAll(x => x.IsDone == true);

            // Always unregister your delegates
            foo.AlarmEvent += OnAlarm;
            foo.AlarmEvent -= OnAlarm;

            // Use "r_" as prefix when finding a child
            gameObject.FindChildByName("r_ButtonText");

            // Declare error code in user-friendly error alerts
            Alert alert = new Alert(ErrorCode.NoInternet, "Your message 'hello' was not send!");
            alert.Show();

        }

        /// <summary>
        /// This method contains bad practices in our conventions
        /// </summary>
        private void BadPractices(Foo foo, Bar bar = null) { // Don't use default parameter values (use overloading instead)

            // Don't declare constants in methods (only in classes)
            const float INCORRECT_CONSTANT = 10.0f;

            // Don't exceed lines over 120 characters
            privateField += MySecondProperty + MyProperty + privateField + privateSecondField + MySecondProperty + privateSecondField;

            // Don't spit on our architecture (code quality, code responsibility)
            GameObject.Find("Foo").GetComponent<Foo>().Bar.Do();

            // Don't put more than 3 parameters in your methods
            foo.Make(MY_PRIVATE_CONSTANT, true, new Bar(), 1.0f, this, "rather put these in a settings struct...");

            // Don't use singletons
            GameManager.Instance.StartGame();

            // Don't use abbreviations
            GM gm = new GM();
            gm.SM.Vlm = 1.0f;

            // Don't use any other language than english
            int mijnWaarde = 0;

            // Don't perform pre-optimizations (note that for is faster than for-each)
            List<Bar> bars = new List<Bar>() { new Bar() };
            int count = bars.Count;
            for (int i = 0; i < count; i++) { // Just use a normal foreach loop for readability
                bars[i].Say();
                bars[i].Do(); 
            }

            // Avoid anonymous delegates
            bar.Load(delegate() {
                privateField++;
            });

            // Don't put curly brackets on new lines
            if (bar == null) 
            {
                return;
            }

            // Don't use if statements without braces
            if (bar == null)
                return;

            // Don't use var
            var value = "not typed";

            // Don't use linq
            Foo[] foos = new Foo[0];
            var numQuery =
                from f in foos
                where f == null
                select f;

            // Don't use UnityEditor components in runtime code
#if UNITY_EDITOR
            EditorApplication.Beep();
#endif

            // Don't use comments, code should speak for itself (exceptions are made on complexs algorythms)
            bar.Do(); // Make bar do do

            // Don't commit green code
            //bar.Say();

            // Don't use comments to define a section of code
            // ############################### CODE SECTION A ###############################\\

            // Don't use regions
            #region Hidden code alert
            #endregion


/// ## End of conventions
/// 
/// This concludes our C# conventions, we hope you got something 
/// out of it.
/// 
/// The following code in this file can be ignored for it is only 
/// here to prevent warnings and demonstrate the code above.


            privateSecondField = 0;
            if (value != null) { Debug.Log(null); }
            if (numQuery != null) { Debug.Log(null);  }
            if (mijnWaarde == 0) { Debug.Log(null); }
            if (INCORRECT_CONSTANT * 1 > 0) { Debug.Log(null); }

        }

        private void OnAlarm(object args) { }

    }

}


namespace Conventions.Demo {

    public enum ErrorCode {
        ServerDown,
        NoInternet,
        FileCorrupted
    }

    public class AbstractClass : MonoBehaviour {
        public AbstractClass(bool myParameter) { }
    }

    public class Bar {
        public bool IsDone { get; private set; }
        public void Do() { }
        public void Say() { }
        public void Load(Action callback) { }
    }

    public class SM {
        public float Vlm;
    }

    public class GM {
        public SM SM;
    }

    public class GameManager {
        public static GameManager Instance;
        public void StartGame() { }
    }

    public class Foo {
        public Bar Bar;
        public MyClass.AlarmEventHandler AlarmEvent;
        public void Make(int i, bool a, Bar b, float j, AbstractClass c, string s) { }
    }

    public class Alert {
        public Alert(ErrorCode errorCode, string errorMessage) { }

        public void Show() {
            throw new NotImplementedException();
        }
    }

    public static class GameObjectHelper {
        public static GameObject FindChildByName(this GameObject gameObject, string name) {
            return null;
        }
    }

}