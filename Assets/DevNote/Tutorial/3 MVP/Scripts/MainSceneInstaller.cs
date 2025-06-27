using UnityEngine;
using Zenject;


namespace DevNote.Tutorial.MVP
{
    // ��� ��������� ��� �����.
    // ������� ���� ������� � ����� ���������� �����. ���� ����� - ���� ���������.
    // �� ���������� ����� ������ ���������� ��� ����� - ��� ������������.
    public class MainSceneInstaller : MonoInstaller
    {
        // ���� �� ����� �� ����� ����������� �����������, ������� ����� ������ � �����������
        [SerializeField] private RectTransform _windowContainer;
        [SerializeField] private MenuButtonView _menuButton;


        public override void InstallBindings()
        {
            // ��� Zenject-��������� �����, ��� ��������� ������ �����
            new SceneInjector(Container);


            // ����� ������� ���������� � ����� �� ������ ���.
            // � ��������� ����������� ����� ���������� ������ �����������
            // ����� � �������� �������� Controller �� �����. ��� ���������� ������ ����������� var.
            var score = Bind(new ScoreController(_windowContainer));
            var menu = Bind(new MenuController(_menuButton));

        }


        // ��� �������� ������ ����������� ��� ������� �� ���� �����������.
        // ��� ��������� ����������� ��� ���������� ����������� �� ProjectContext.
        private T Bind<T>(T controller) where T : class
        {
            ProjectInstaller.ProjectContainer.Inject(controller);
            Container.BindInterfacesAndSelfTo<T>().FromInstance(controller).AsSingle();
            return controller;
        }
    }
}

