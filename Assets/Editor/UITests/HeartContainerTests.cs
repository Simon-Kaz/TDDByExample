using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Image = UnityEngine.UI.Image;

public class HeartContainerTests
{

    [SetUp]
    public void SetUp()
    {
        // Arrange
        SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator OnGetHit_Reduces_FillAmount()
    {
        GameObject testContainer = null;
        yield return new WaitUntil(() => (testContainer = GameObject.Find("HeartContainer")) != null);

        testContainer.GetComponent<Image>().fillAmount = 1;

        // Act
        testContainer.GetComponent<HeartView>().OnGetHit();

        yield return new WaitForEndOfFrame();

        // Assert
        testContainer.GetComponent<Image>().fillAmount = 0.75f;
    }

    [UnityTest]
    public IEnumerator OnHealthItemPickup_Increases_FillAmount()
    {
        GameObject testContainer = null;
        yield return new WaitUntil(() => (testContainer = GameObject.Find("HeartContainer")) != null);

        // Set the fill rate to max
        testContainer.GetComponent<Image>().fillAmount = 0f;

        // Act
        testContainer.GetComponent<HeartView>().OnHealthItemPickup();

        yield return new WaitForEndOfFrame();

        // Assert
        testContainer.GetComponent<Image>().fillAmount = 0.25f;
    }
}