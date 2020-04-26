import { MdProAngularCliPage } from './app.po';

describe('md-pro-angular-cli App', () => {
  let page: MdProAngularCliPage;

  beforeEach(() => {
    page = new MdProAngularCliPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
