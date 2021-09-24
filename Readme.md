# **Unity Test Runner + AltUnity Tester**

This project is an example for testing a game using both Unity Test Framework and AltUnity Tester.

To run unit tests, open the Test Runner Editor Window by clicking Window->General->Test Runner. Select the "Run all" tab and check the test results.

To run AltUnity tests, open the AltUnity Tester Editor window from AltUnity Tools-> AltUnity Tester Editor. Make sure the "Editor" is selected in the Platform section, click on "Play in Editor" and once the game is started run the tests by selecting "Run all" or "Run Selected".

If you are following our example and are willing to use both Unity Test Framework and AltUnity Tester, you will eventually have to deal with three test assemblies: 
<ul>
<li>PlayMode Tests</li>
<li>EditMode Tests</li>
<li>AltUnity Tests</li>
</ul>
When working in Unity, you might see that the EditMode assembly is visible in the AltUnity Tester Editor and the other way around as well. Running the tests from the Editor they don’t belong to, won’t give you any information about the tests results. Their presence there won’t impact your work.

For more information on how to write and run tests using AltUnity Tester you can check our tutorial here https://www.youtube.com/watch?v=L4yAgv8Jc8s


