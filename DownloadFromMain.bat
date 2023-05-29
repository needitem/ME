@echo off
git checkout Kijun
git add -A
git commit
git push
git pull origin main
git merge origin/main