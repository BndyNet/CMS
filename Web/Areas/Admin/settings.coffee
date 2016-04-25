@settings =
    enableSidebar: true
    menus: [
        {
            icon: 'fa fa-home fa-fw'
            text: 'Home'
            description: 'Control Panel'
            url: '/home'
        }
        {
            text: 'Multilevel'
            children: [
                {
                    text: 'Level One 1'
                }
                {
                    text: 'Level One 2'
                }
                {
                    text: 'Level One 3'
                }
            ]
        }
        {
            text: 'LABELS'
            isHeader: true
        }
        {
            text: 'Primary'
        }
        {
            text: 'Warning'
        }
        {
            text: 'Default'
        }
    ]