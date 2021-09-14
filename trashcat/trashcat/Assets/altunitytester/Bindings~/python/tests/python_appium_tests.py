import os
import unittest
import sys

from appium import webdriver
from altunityrunner import AltUnityDriver
from altunityrunner.by import By
from altunityrunner import AltUnityPortForwarding


def PATH(p): return os.path.abspath(
    os.path.join(os.path.dirname(__file__), p)
)


class SampleAppiumTest(unittest.TestCase):
    altdriver = None
    platform = "android"  # set to `ios` or `android` to change platform
    iProxyProcessID = -1

    @classmethod
    def setUpClass(cls):
        cls.desired_caps = {}
        if cls.platform == "android":
            cls.setup_android()
            AltUnityPortForwarding.forward_android()
        else:
            cls.setup_ios()
            cls.iProxyProcessID = AltUnityPortForwarding.forward_ios()

        cls.driver = webdriver.Remote(
            'http://localhost:4723/wd/hub', cls.desired_caps)
        cls.altdriver = AltUnityDriver(log_flag=True)

    @classmethod
    def tearDownClass(cls):
        cls.altdriver.stop()
        cls.driver.quit()
        if cls.platform == "android":
            AltUnityPortForwarding.remove_forward_android()
        else:
            AltUnityPortForwarding.kill_iproxy_process(cls.iProxyProcessID)

    @classmethod
    def setup_android(cls):
        cls.desired_caps['platformName'] = 'Android'
        cls.desired_caps['deviceName'] = 'device'
        cls.desired_caps['app'] = PATH('../../../sampleGame.apk')

    @classmethod
    def setup_ios(cls):
        cls.desired_caps['platformName'] = 'iOS'
        cls.desired_caps['deviceName'] = 'iPhone5'
        cls.desired_caps['automationName'] = 'XCUITest'
        cls.desired_caps['app'] = PATH('../../../sampleGame.ipa')

    def test_find_object_and_tap(self):
        # tap UIButton to make capsule jump
        self.altdriver.find_object(By.NAME, 'UIButton').tap()
        capsule_info = self.altdriver.wait_for_object_with_text(
            By.NAME, 'CapsuleInfo', 'UIButton clicked to jump capsule!')
        self.assertEqual('UIButton clicked to jump capsule!',
                         capsule_info.get_text())

        # tap capsule to make it jump
        self.altdriver.find_object(By.NAME, 'Capsule').tap()
        capsule_info = self.altdriver.wait_for_object_with_text(
            By.NAME, 'CapsuleInfo', 'Capsule was clicked to jump!')
        self.assertEqual('Capsule was clicked to jump!',
                         capsule_info.get_text())


if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SampleAppiumTest)
    result = unittest.TextTestRunner(verbosity=2).run(suite)
    sys.exit(not result.wasSuccessful())
