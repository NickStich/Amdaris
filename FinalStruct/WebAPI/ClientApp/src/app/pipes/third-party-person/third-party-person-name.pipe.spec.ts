import { ThirdPartyPersonNamePipe } from './third-party-person-name.pipe';

describe('ThirdPartyPersonNamePipe', () => {
  it('create an instance', () => {
    const pipe = new ThirdPartyPersonNamePipe();
    expect(pipe).toBeTruthy();
  });
});
